using UnityEngine;


public class Gun : MonoBehaviour
{
    // временный объект пули
    private GameObject bullet;

    // расстояние от стреляющего объекта до начала показа пули
    private const float DistanceBetweenBulletAndObject = 2.1f;

    private static GameObject bulletPrefab = null;

    public void LoadBulletPrefab()
    {
        if (!bulletPrefab)
        {
            bulletPrefab = Resources.Load<GameObject>("Levels/First/Prefabs/bullet");
        }
    }

    private void CreateBulletInstance()
    {
        LoadBulletPrefab();
        bullet = Instantiate(bulletPrefab, transform.position + transform.up / DistanceBetweenBulletAndObject, transform.rotation);
    }

    public void Shot()
    {
        CreateBulletInstance();
        bullet.GetComponent<Bullet>().BulletParamsInit();
    }
}
