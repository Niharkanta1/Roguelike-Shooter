using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       13-03-2023 22:41:47
================================================*/ 
public class BrokenPieces : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 3.0f;
    [SerializeField] public float deacceleration = 5.0f;
    [SerializeField] public float lifeTime = 3.0f;
    [SerializeField] public float fadeSpeed = 3.0f;

    private Vector3 _moveDirection;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _moveDirection.x = Random.Range(-moveSpeed, moveSpeed);
        _moveDirection.y = Random.Range(-moveSpeed, moveSpeed);
    }

    private void Update()
    {
        transform.position += _moveDirection * Time.deltaTime;
        _moveDirection = Vector3.Lerp(_moveDirection, Vector3.zero, deacceleration * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            // Fadeout Color
            _spriteRenderer.color = new Color(
                _spriteRenderer.color.r, 
                _spriteRenderer.color.g, 
                _spriteRenderer.color.b, 
                Mathf.MoveTowards(_spriteRenderer.color.a, 0.0f, fadeSpeed * Time.deltaTime)
                );
            if (_spriteRenderer.color.a == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}