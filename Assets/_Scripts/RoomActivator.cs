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
public class RoomActivator : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CameraController.instance.SetTarget(transform);
        }
    }
}