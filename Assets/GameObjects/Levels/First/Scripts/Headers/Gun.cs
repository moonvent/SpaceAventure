using System.Collections;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    protected GameObject bullet;

    // расстояние от стреляющего объекта до начала показа пули
    private const float DistanceBetweenBulletAndObject = 2.1f;

    private static GameObject bulletPrefab = null;

    private void LoadBulletPrefab()
    {
        if (!bulletPrefab)
        {
            bulletPrefab = Resources.Load<GameObject>("Levels/First/Prefabs/bullet");
        }
    }

    protected void CreateBulletInstance()
    {
        LoadBulletPrefab();
        bullet = Instantiate(bulletPrefab, transform.position + transform.up / DistanceBetweenBulletAndObject, transform.rotation);
    }

    public virtual void Shot() { }
}
