using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       15-03-2023 11:35:07
================================================*/ 
public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [SerializeField] private float moveSpeed = 30.0f;
    [SerializeField] private Transform target;
    
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (target == null) return;
        transform.position = Vector3.MoveTowards(
            transform.position, 
            new Vector3(target.position.x, target.position.y, transform.position.z),
            moveSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }
}