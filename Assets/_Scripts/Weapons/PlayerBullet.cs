using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       10-03-2023 13:42:18
================================================*/
public class PlayerBullet : Bullet
{
    protected override void BulletImpact(Collider2D other)
    {
        Instantiate(impactEffect, impactPoint.position, impactPoint.rotation);
        AudioManager.instance.PlaySound(4);
        Destroy(gameObject);
        if (other.CompareTag("Enemy"))
        {
            other.GetComponentInParent<EnemyController>().Hit(bulletDamage);
        } else if (other.CompareTag("Obstacles"))
        {
            other.GetComponent<Breakable>().Hit(bulletDamage);
        }
        
    }
}