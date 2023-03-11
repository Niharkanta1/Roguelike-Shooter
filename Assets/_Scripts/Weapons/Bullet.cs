using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       11-03-2023 13:07:28
================================================*/ 
public abstract class Bullet : MonoBehaviour {
    [SerializeField] private float bulletSpeed = 12.0f;
    [SerializeField] protected int bulletDamage = 50;
    [SerializeField] private float bulletLifeSpan = 1.0f;
    [SerializeField] private bool isRigidBody = true;
    [SerializeField] protected Transform impactPoint;
    [SerializeField] protected GameObject impactEffect;

    private Rigidbody2D _rb;
    private float _lifeTimer;

    private void Awake()
    {
        if(isRigidBody)
            _rb = GetComponent<Rigidbody2D>();
        _lifeTimer = bulletLifeSpan;
    }

    private void Update()
    {
        _lifeTimer -= Time.deltaTime;
        if (_lifeTimer <= 0)
            Destroy(gameObject);
        if (isRigidBody)
            _rb.velocity = transform.right * bulletSpeed;
        else
            transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

    protected abstract void BulletImpact(Collider2D other);
    protected void OnTriggerEnter2D(Collider2D other)
    {
        BulletImpact(other);
    }
}