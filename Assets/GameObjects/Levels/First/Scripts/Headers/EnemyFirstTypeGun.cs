using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFirstTypeGun : Gun
{
    private void SeriesOfShots()
    {
        CreateBulletInstance();
        bullet.GetComponent<Bullet>().BulletParamsInit();
    }

    public override void Shot()
    {
        while (true)
        {
            SeriesOfShots();

        }
    }
}
