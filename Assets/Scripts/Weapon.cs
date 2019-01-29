using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;  // If fireRate = 1 then it is Single Burst otherwise its mutlishot
    public int Damage = 10;
    public LayerMask whatToHit;

    // Handle camera shaking
    private float camShakeAmt = 0.1f;
    private float camShakeLength = 0.2f;
    CameraShake camShake;

    public Transform BulletTrainPrefab;
    public Transform MuzzleFlashPrefab;
    public Transform HitPrefab;
    private float timeToFire = 1;
    private Transform firePoint;
    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;

    // Use this for initialization
    void Awake () {
        firePoint = transform.Find("FirePoint");
        if(firePoint == null)
        {
            Debug.LogError("Didnt find a fire point. Error raised.");
        }
	}

    private void Start()
    {
        camShake = GameMaster.gm.GetComponent<CameraShake>();
        if(camShake == null)
        {
            Debug.LogError("No CameraShake script found on GM object.");
        }
    }

    // Update is called once per frame
    void Update () {
		if(fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if(Input.GetButtonDown("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);

        Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);
        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            Boss boss = hit.collider.GetComponent<Boss>();

            if(enemy != null)
            {
                enemy.DamageEnemy(Damage);
                //Debug.Log("We hit " + hit.collider + "and did " + Damage + " damage.");
            }else if(boss != null)
            {
                boss.DamageEnemy(Damage);
            }
        }
        if (Time.time >= timeToSpawnEffect)
        {
            Vector3 hitPos;
            Vector3 hitNormal;

            if (hit.collider == null)
            {
                hitPos = (mousePosition - firePointPosition) * 30;
                hitNormal = new Vector3(9999, 9999, 9999);
            }
            else
            {
                hitPos = hit.point;
                hitNormal = hit.normal;
            }

            Effect(hitPos, hitNormal);
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
    }
    void Effect(Vector3 hitPos, Vector3 hitNormal)
    {
        Transform trail = Instantiate(BulletTrainPrefab, firePoint.position, firePoint.rotation) as Transform;
        LineRenderer lr = trail.GetComponent<LineRenderer>();
        if(lr != null)
        {
            lr.SetPosition(0, firePoint.position);
            lr.SetPosition(1, hitPos);
        }
        Destroy(trail.gameObject, 0.04f);

        if(hitNormal != new Vector3(9999, 9999, 9999))
        {
            Transform hitParticle = Instantiate(HitPrefab, hitPos, Quaternion.FromToRotation(Vector3.right, hitNormal)) as Transform;
            Destroy(hitParticle.gameObject, 1f);
        }
        Transform clone = Instantiate(MuzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);

        // Shake camera
        camShake.Shake(camShakeAmt, camShakeLength);
    }
}
