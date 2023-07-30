using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    // временный объект пули
    private Bullet bullet;

    public void Shot(Transform ShotObjectTransformField)
    {
        // bullet = gameObject.AddComponent<Bullet>();
        // bullet.CreateBulletInstance(ShotObjectTransformField);
        gameObject.AddComponent<Bullet>().CreateBulletInstance(ShotObjectTransformField);
    }
}
