using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       13-03-2023 22:23:43
================================================*/ 
public class Breakable : MonoBehaviour
{
    public GameObject[] brokenPieces;
    public int maxPieces = 5;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!PlayerController.instance.IsDashing())
                return;
            Destroy(gameObject);
            var piecesToDrop = Random.Range(1, maxPieces);
            for (var i = 0; i < piecesToDrop; i++)
            {
                var randomPiece = Random.Range(0, brokenPieces.Length);
                Instantiate(brokenPieces[randomPiece], transform.position, transform.rotation);
            }
        }
    }
}