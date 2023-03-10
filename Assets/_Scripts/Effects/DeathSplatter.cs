using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       10-03-2023 16:54:07
================================================*/ 
public class DeathSplatter : MonoBehaviour {

    [SerializeField] private Sprite[] splatterSprites;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        var selectedIndex = Random.Range(0, splatterSprites.Length);
        spriteRenderer.sprite = splatterSprites[selectedIndex];
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 180));
    }
}