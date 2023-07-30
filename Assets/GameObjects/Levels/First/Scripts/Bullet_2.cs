// using UnityEngine;
//
//
// /// <summary>
// /// Кастомный объект пули
// /// </summary>
// public class Bullet : MonoBehaviour
// {
//
//     private static GameObject bulletPrefab = null;
//
//     private GameObject bullet;
//
//     // скорость пули
//     private const float BulletSpeed = 15f;
//
//     // расстояние от стреляющего объекта до начала показа пули
//     private const float DistanceBetweenBulletAndObject = 2.1f;
//
//     // время, после которого пуля будет уничтожена
//     private const float TimeToDestroyBullet = 1f;
//
//     // список пуль
//     private BulletList bulletList = new BulletList();
//
//     public void LoadPrefab()
//     {
//         if (!bulletPrefab)
//         {
//             bulletPrefab = Resources.Load<GameObject>("Levels/First/Prefabs/bullet");
//         }
//     }
//
//
//     private void OnDestroy()
//     {
//         bulletList.DestroyBullet(this);
//         Destroy(bullet);
//     }
//
//     private void OnCollisionEnter(Collision collision)
//     {
//         Debug.Log(collision);
//     }
//
//     public void CreateBulletInstance(Transform ShotObjectTransformField)
//     {
//         LoadPrefab();
//
//         bullet = Instantiate(bulletPrefab, ShotObjectTransformField.position + ShotObjectTransformField.up / DistanceBetweenBulletAndObject, ShotObjectTransformField.rotation);
//
//         bullet.GetComponent<Rigidbody2D>().velocity = ShotObjectTransformField.up * BulletSpeed;
//
//         // bullet.OnCollisionEnter = OnCollisionEnter;
//
//         bulletList.AddNewBullet(this);
//
//         Destroy(this, TimeToDestroyBullet);
//     }
// }
