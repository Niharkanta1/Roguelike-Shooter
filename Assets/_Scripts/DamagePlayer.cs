using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       12-03-2023 23:09:57
================================================*/ 
public class DamagePlayer : MonoBehaviour
{

    [SerializeField] private int damageValue = 50;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerController.instance.Hit(damageValue);
    }
}