using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       11-03-2023 13:13:44
================================================*/
public class EnemyBullet : Bullet
{
    protected override void BulletImpact(Collider2D other)
    {
        Instantiate(impactEffect, impactPoint.position, impactPoint.rotation);
        AudioManager.instance.PlaySound(3);
        Destroy(gameObject);
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<PlayerController>().Hit(bulletDamage);
        }
    }
}