using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

    public Transform player;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    private float timeBetweenSpecialShots;
    public float startTimeBetweenSpecialShots;


    public GameObject projectile;
    public GameObject specialProjectile;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = startTimeBetweenShots;
        timeBetweenSpecialShots = startTimeBetweenSpecialShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else if (timeBetweenSpecialShots <= 0 && GameObject.FindObjectOfType<Boss>())
        {
            Instantiate(specialProjectile, transform.position, Quaternion.identity);
            timeBetweenSpecialShots = startTimeBetweenSpecialShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
            timeBetweenSpecialShots -= Time.deltaTime;
        }
    }
}
