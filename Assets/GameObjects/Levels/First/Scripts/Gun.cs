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

    private void CreateBulletInstance(Transform ShotObjectTransformField)
    {
        LoadBulletPrefab();
        bullet = Instantiate(bulletPrefab, ShotObjectTransformField.position + ShotObjectTransformField.up / DistanceBetweenBulletAndObject, ShotObjectTransformField.rotation);
    }

    public void Shot(Transform ShotObjectTransformField)
    {
        CreateBulletInstance(ShotObjectTransformField);
        bullet.GetComponent<Bullet>().BulletParamsInit(ShotObjectTransformField);
    }
}
