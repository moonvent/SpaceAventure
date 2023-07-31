using UnityEngine;


/// <summary>
/// Кастомный объект пули
/// </summary>
public class Bullet : Entity
{
    // скорость пули
    private const float BulletSpeed = 15f;

    // расстояние от стреляющего объекта до начала показа пули
    private const float DistanceBetweenBulletAndObject = 2.1f;

    // время, после которого пуля будет уничтожена
    private const float TimeToDestroyBullet = 1f;

    // объект с которым встретилась пуля
    private Entity collisionEntity;

    void Awake()
    {
        healPoints = 1;
    }


    /// <summary>
    /// При коллизии с каким-либо объектом, мы отнимаем у объекта жизнь, и уничтожаем пулю
    /// </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == BulletConstants.BulletTag)
            return;
        else if (collision.gameObject.tag == ShuttleConstants.ShuttleTag)
        {
            collisionEntity = collision.gameObject.GetComponent<Entity>();
            collisionEntity.descreaseHealPoints(BulletConstants.BulletDamage);
            // Debug.Log(collision.gameObject.tag);
        }
    }

    /// <summary>
    /// Инициализация пули, направления куда летит, когда должна быть уничтожена, и т.д.
    /// </summary>
    public void BulletParamsInit(Transform ShotObjectTransformField)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = ShotObjectTransformField.up * BulletSpeed;

        Destroy(gameObject, TimeToDestroyBullet);
    }
}
