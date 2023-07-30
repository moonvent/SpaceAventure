using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private GameObject bulletPrefab;

    private GameObject bullet;

    // скорость пули
    private const float BulletSpeed = 15f;

    // расстояние от стреляющего объекта до начала показа пули
    private const float DistanceBetweenBulletAndObject = 2.1f;

    // время, после которого пуля будет уничтожена
    private const float TimeToDestroyBullet = 1f;

    void Awake()
    {

    }

    public void Init(GameObject loadedBulletPrefab)
    {
        bulletPrefab = loadedBulletPrefab;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        Debug.Log("bullet destroyed");
        Destroy(bullet);
    }

    public void CreateBulletInstance(GameObject loadedBulletPrefab, Transform ShotObjectTransformField)
    {
        bullet = Instantiate(loadedBulletPrefab, ShotObjectTransformField.position + ShotObjectTransformField.up / DistanceBetweenBulletAndObject, ShotObjectTransformField.rotation);

        bullet.GetComponent<Rigidbody2D>().velocity = ShotObjectTransformField.up * BulletSpeed;
        //
        // Destroy(bullet, TimeToDestroyBullet);
        //
        // bullet.OnDestroy = OnDestroyBullet;
        //
        // bulletList.Add(this);
        // Debug.Log(this);
    }
}
