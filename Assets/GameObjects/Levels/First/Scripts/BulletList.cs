using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class BulletList
{
    private static List<Bullet> bulletList = new List<Bullet>();

    public void AddNewBullet(Bullet bullet)
    {
        bulletList.Add(bullet);
        Debug.Log(bulletList.Count);
    }

    public void DestroyBullet(Bullet bullet)
    {
        bulletList.Remove(bullet);
    }
}
