using UnityEngine;


public class ShuttleGun : Gun
{
    public override void Shot()
    {
        CreateBulletInstance();
        bullet.GetComponent<Bullet>().BulletParamsInit();
    }
}
