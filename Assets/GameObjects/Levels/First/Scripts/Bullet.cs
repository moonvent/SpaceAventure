using UnityEngine;


/// <summary>
/// Кастомный объект пули
/// </summary>
public class Bullet : MonoBehaviour
{
    // скорость пули
    private const float BulletSpeed = 15f;

    // расстояние от стреляющего объекта до начала показа пули
    private const float DistanceBetweenBulletAndObject = 2.1f;

    // время, после которого пуля будет уничтожена
    private const float TimeToDestroyBullet = 1f;


    /// <summary>
    /// При коллизии с каким-либо объектом, мы отнимаем у объекта жизнь, и уничтожаем пулю
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }

    /// <summary>
    /// Инициализация пули, направления куда летит, когда должна быть уничтожена, и т.д.
    /// </summary>
    public void BulletParamsInit(Transform ShotObjectTransformField)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = ShotObjectTransformField.up * BulletSpeed;
        //
        // // bulletList.AddNewBullet(this);

        Destroy(gameObject, TimeToDestroyBullet);
    }
}
