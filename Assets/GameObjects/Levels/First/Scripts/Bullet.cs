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

    // сущность объекта с которым произошла коллизия
    private Entity collisionEntity;

    // объект с которым произошла коллизия
    private GameObject collisionObject;

    // урон пули
    private int bulletDamage;

    // тег объекта с которым произошла коллизия
    private string collisionTag;

    void Awake()
    {
        healPoints = BulletConstants.BulletHeal;
        bulletDamage = BulletConstants.BulletDamage;
    }

    /// <summary>
    /// При коллизии с каким-либо объектом, мы отнимаем у объекта жизнь, и уничтожаем пулю
    /// </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        collisionTag = collision.gameObject.tag;

        collisionObject = collision.gameObject;
        if (collisionTag != BulletConstants.BulletTag)
        {
            collisionEntity = collision.gameObject.GetComponent<Entity>();

            // if (collisionEntity)
            collisionEntity.descreaseHealPoints(bulletDamage);
        }
    }

    /// <summary>
    /// Инициализация пули, направления куда летит, когда должна быть уничтожена, и т.д.
    /// </summary>
    public void BulletParamsInit()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * BulletSpeed;

        Destroy(gameObject, TimeToDestroyBullet);
    }
}
