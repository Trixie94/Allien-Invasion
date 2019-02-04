using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int fireRate = 0;
    private float timeToFire;
    

    private void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 0.42f/ fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
