using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject impactEffect;

    private void Start()
    {
        rb.velocity = transform.right * speed;    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        Boss boss = other.GetComponent<Boss>();
        if(enemy != null)
        {
            enemy.DamageEnemy(damage);
        }
        if(boss != null)
        {
            boss.DamageEnemy(damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
