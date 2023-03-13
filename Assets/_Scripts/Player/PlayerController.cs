using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       09-03-2023 23:51:14
================================================*/ 
public class PlayerController : MonoBehaviour, IHittable
{
    public static PlayerController instance;
    
    [Header("Player Stats")]
    [SerializeField] private int maxHealth = 200;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float timeBetweenShots = 0.2f;
    [SerializeField] private float invincibleTime = 1.0f;
    [SerializeField] private float dashSpeed = 8.0f;
    [SerializeField] private float dashLengthTime = 0.5f;
    [SerializeField] private float dashCoolDownTime = 1.0f;

    [Header("Prefabs")]
    [SerializeField] private Transform gunArm;
    [SerializeField] private Transform gunMuzzle;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject hitEffect;

    private Rigidbody2D _rb;
    private Camera _cameraMain;
    private Animator _animator;
    private Vector2 _moveInput;
    private SpriteRenderer[] _spriteRenderers;

    private float _fireRateTimer;
    private float _iFrameTimer;
    private bool _canBeHit;
    private int _health;
    private float _dashTimer, _dashCooldownTimer;
    private float _activeMoveSpeed;
    
    private void Awake()
    {
        instance = this;
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        _cameraMain = Camera.main;
        _animator = GetComponent<Animator>();
        _animator.Play("Player_Idle");
        _health = maxHealth;
        _activeMoveSpeed = moveSpeed;
    }

    private void Start()
    {
        UIController.instance.InitHealthUI(_health);
    }

    private void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");

        var mousePos = Input.mousePosition;
        var screenPoint = _cameraMain.WorldToScreenPoint(transform.position);
        
        // Update Player Direction
        if(mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            gunArm.localScale = new Vector3(-1, -1, 1);
        } else if(mousePos.x > screenPoint.x)
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
        }
 
        // Rotating Gun Arm towards mouse point
        var offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.transform.rotation = Quaternion.Euler(0, 0, angle); 

        // Update Animation params
        if(_moveInput != Vector2.zero)
        {
            _animator.SetBool("isMoving", true);
        } else
        {
            _animator.SetBool("isMoving", false);
        }

        // Shoot Input
        if (Input.GetMouseButtonDown(0)) ShootBullet();
        if(Input.GetMouseButton(0))
        {
            _fireRateTimer -= Time.deltaTime;
            if (_fireRateTimer <= 0)
                ShootBullet();                
        }
        
        // Dash Movement
        if (_dashCooldownTimer > 0)
        {
            _dashCooldownTimer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _dashCooldownTimer <= 0 && _dashTimer <= 0)
        {
            _activeMoveSpeed = dashSpeed;
            SetInvincibility(dashLengthTime);
            _dashTimer = dashLengthTime;
        }
        if (_dashTimer > 0)
        {
            _dashTimer -= Time.deltaTime;
            if (_dashTimer <= 0)
            {
                _activeMoveSpeed = moveSpeed;
                _dashCooldownTimer = dashCoolDownTime;
                ClearInvincibility();
            }
        }
        
        _rb.velocity = _moveInput.normalized * _activeMoveSpeed;
        // I-Frame
        if(!_canBeHit)
        {
            _iFrameTimer -= Time.deltaTime;
            if (_iFrameTimer <= 0)
                ClearInvincibility();
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, gunMuzzle.position, gunMuzzle.rotation);
        _fireRateTimer = timeBetweenShots;
    }

    public void SetHealth(int heal)
    {
        _health += heal;
        _health = Math.Min(maxHealth, _health);
    }

    public void Hit(int damage)
    {
        if (!_canBeHit) return;
        SetInvincibility(invincibleTime);
        _health -= damage;
        UIController.instance.SetCurrentHealth(_health);
        Instantiate(hitEffect, transform.position, transform.rotation);
        if (_health <= 0)
        {
            Die();
        }
    }

    private void SetInvincibility(float iFrameTime)
    {
        _canBeHit = false;
        _iFrameTimer = iFrameTime;
        foreach(var sprite in _spriteRenderers)
        {
            sprite.color = new Color(1, 1, 1, 0.7f);
        }
            
    }

    private void ClearInvincibility()
    {
        _canBeHit = true;
        foreach (var sprite in _spriteRenderers)
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
    }

    private void Die()
    {
        Debug.Log("Player Died");
        gameObject.SetActive(false);
    }
}