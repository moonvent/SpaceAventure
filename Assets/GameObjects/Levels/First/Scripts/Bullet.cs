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
    private GameObject collisionObject;

    // сущность объекта с которым произошла коллизия
    private Entity collisionEntity;

    // объект владелец пули
    private GameObject owner;

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
            collisionObject = collision.gameObject;

            if (collisionObject != owner)
            {
                collisionEntity = collision.gameObject.GetComponent<Entity>();
                collisionEntity.descreaseHealPoints(BulletConstants.BulletDamage);
            }
        }
    }

    /// <summary>
    /// Инициализация пули, направления куда летит, когда должна быть уничтожена, и т.д.
    /// <param name="ownerGameObject">Владелец пули, нужно чтобы сам себя не убил, ибо так работает, что если лететь в ту сторону в которую стреляешь наносишь урон сам себе</param>
    /// </summary>
    public void BulletParamsInit(GameObject ownerGameObject)
    {
        owner = ownerGameObject;
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * BulletSpeed;

        Destroy(gameObject, TimeToDestroyBullet);
    }
}
