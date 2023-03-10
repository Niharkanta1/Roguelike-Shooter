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
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float timeBetweenShots = 0.2f;

    [SerializeField] private Transform gunArm;
    [SerializeField] private Transform gunMuzzle;
    [SerializeField] private GameObject bulletPrefab;

    private Rigidbody2D _rb;
    private Camera _cameraMain;
    private Animator _animator;
    private Vector2 _moveInput;

    private float _fireRateTimer;

    private void Awake()
    {
        instance = this;
        _rb = GetComponent<Rigidbody2D>();
        _cameraMain = Camera.main;
        _animator = GetComponent<Animator>();
        _animator.Play("Player_Idle");
    }

    private void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");

        _rb.velocity = _moveInput.normalized * moveSpeed;

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
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, gunMuzzle.position, gunMuzzle.rotation);
        _fireRateTimer = timeBetweenShots;
    }
}