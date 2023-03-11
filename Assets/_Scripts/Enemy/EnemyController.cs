using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       10-03-2023 15:08:06
================================================*/
public class EnemyController : MonoBehaviour, IHittable
{
    [SerializeField] protected int health = 150;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float enemyMaxRange = 6f;
    [SerializeField] private float enemyMinRange = 0.5f;
    [SerializeField] private bool shouldShoot = false;
    [SerializeField] private float shootingRange = 8.5f;
    [SerializeField] private float fireRate = 1f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject deathSplatter;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Transform gunArm;

    private Rigidbody2D _rb;
    private Animator _animator;

    private Vector3 _moveDirection;
    private float fireRateCounter;
    private bool isShooting = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
        _moveDirection = PlayerController.instance.transform.position - transform.position;
        isShooting = distance <= shootingRange;
        if ( distance <= enemyMaxRange && distance > enemyMinRange)
        {
            _rb.velocity = _moveDirection.normalized * moveSpeed;
        } else
        {
            _rb.velocity = Vector2.zero;
        }
        // Enemy Direction
        if (_moveDirection.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            gunArm.localScale = new Vector3(-1, -1, 1);
        } else if (_moveDirection.x < 0)
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
        }

        // Rotating Gun Arm towards mouse point
        var offset = new Vector2(_moveDirection.x, _moveDirection.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Update Animation params
        if (_moveDirection != Vector3.zero)
        {
            _animator.SetBool("isMoving", true);
        } else
        {
            _animator.SetBool("isMoving", false);
        }

        // Shooting
        if(shouldShoot && isShooting)
        {
            fireRateCounter -= Time.deltaTime;
            if(fireRateCounter <= 0)
            {
                fireRateCounter = fireRate;
                Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            }
        }
    }

    public void Hit(int damage)
    {
        health -= damage;
        Instantiate(hitEffect, transform.position, transform.rotation);
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathSplatter, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
   