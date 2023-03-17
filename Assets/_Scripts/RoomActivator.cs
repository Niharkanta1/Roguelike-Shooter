using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       15-03-2023 11:43:07
================================================*/ 
public class RoomActivator : MonoBehaviour
{
    [SerializeField] private bool closeWhenEntered, openWhenEnemyCleared;
    [SerializeField] private GameObject[] doors;
    [SerializeField] public List<GameObject> enemies = new List<GameObject>();

    public bool roomActive;
    
    private void Update()
    {
        if (enemies.Count > 0 && roomActive && openWhenEnemyCleared)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == null)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }
            if (enemies.Count == 0)
            {
                foreach (var door in doors)
                {
                    door.SetActive(false);
                }
                closeWhenEntered = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CameraController.instance.SetTarget(transform);
            if (!closeWhenEntered)
                return;
            
            foreach (var door in doors)
            {
                door.SetActive(true);
            }
            roomActive = true;
        }
    }
}