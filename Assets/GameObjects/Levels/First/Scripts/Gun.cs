using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    // префаб пули
    private GameObject BulletPrefab;

    // временный объект пули
    private Bullet bullet;


    // время, после которого пуля будет уничтожена
    private const float TimeToDestroyBullet = 1f;

    private void LoadPrefabs()
    {
        BulletPrefab = Resources.Load<GameObject>("Levels/First/Prefabs/bullet");
    }

    private void Awake()
    {
        LoadPrefabs();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shot(Transform ShotObjectTransformField)
    {
        bullet = gameObject.AddComponent<Bullet>();
        bullet.CreateBulletInstance(BulletPrefab, ShotObjectTransformField);
    }
}
