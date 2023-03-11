using System;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       11-03-2023 14:00:50
================================================*/

public interface IHittable
{
    void Hit(int damage);
}