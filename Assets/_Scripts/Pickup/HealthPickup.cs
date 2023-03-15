using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       13-03-2023 23:17:25
================================================*/ 
public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healAmount = 50;
    [SerializeField] private float spawnTime = 0.5f;

    private void Update()
    {
        if (spawnTime > 0)
            spawnTime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawnTime > 0) return;
            var isPickedUp = PlayerController.instance.AddHealth(healAmount);
            if (!isPickedUp) return;
            AudioManager.instance.PlaySound(7);
            Destroy(gameObject);
        }
    }
}