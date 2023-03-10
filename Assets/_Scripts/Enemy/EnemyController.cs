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
public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health = 150;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float enemyRange = 6f;

    [SerializeField] private GameObject deathSplatter;
    [SerializeField] private GameObject hitEffect;

    private Rigidbody2D _rb;
    private Animator _animator;

    private Vector3 _moveDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= enemyRange)
        {
            _moveDirection = PlayerController.instance.transform.position - transform.position;
        } else
        {
            _moveDirection = Vector2.zero;
        }
        _rb.velocity = _moveDirection.normalized * moveSpeed;

        // Enemy Direction
        if (_moveDirection.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (_moveDirection.x < 0)
        {
            transform.localScale = Vector3.one;
        }

        // Update Animation params
        if (_moveDirection != Vector3.zero)
        {
            _animator.SetBool("isMoving", true);
        } else
        {
            _animator.SetBool("isMoving", false);
        }
    }

    public void DamageEnemy(int damage)
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
   