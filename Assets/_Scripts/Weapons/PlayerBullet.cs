using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       10-03-2023 13:42:18
================================================*/ 
public class PlayerBullet : MonoBehaviour {

    [SerializeField] private float bulletSpeed = 12.0f;
    [SerializeField] private int bulletDamage = 50;
    [SerializeField] private float bulletLifeSpan = 1.0f;
    [SerializeField] private Transform impactPoint;
    [SerializeField] private GameObject impactEffect;

    private Rigidbody2D _rb;
    private float _lifeTimer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lifeTimer = bulletLifeSpan;
    }

    private void Update()
    {
        _lifeTimer -= Time.deltaTime;
        if (_lifeTimer <= 0)
            Destroy(gameObject);
        _rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, impactPoint.position, impactPoint.rotation);
        Destroy(gameObject);
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().DamageEnemy(bulletDamage);
        }
            
    }
}