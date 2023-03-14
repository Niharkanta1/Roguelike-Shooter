using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       13-03-2023 23:09:16
================================================*/ 
public class SpriteSortOrder : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -1);
    }
}