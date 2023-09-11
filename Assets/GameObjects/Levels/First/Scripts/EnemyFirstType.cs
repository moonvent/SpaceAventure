using UnityEngine;
using System;


public class EnemyFirstType : SpaceFlyObject
{
    // обхект который нужно приследовать
    private Shuttle shuttle;

    // расстояние до игрока
    private float distanceToPlayer;

    protected EnemyFirstTypeGun gun;

    // префаб разрушенного врага 
    private static GameObject destroyedFirstEnemyPrefab;

    // объект разрушенного врага
    private GameObject destroyedFirstEnemyObject;

    // рандомайзер для будущих нужд
    private System.Random randomizer;

    private GameObject collisionObject;

    // сущность с которой происходит коллизия
    private Entity collisionEntity;

    // тег объекта с которым произошла коллизия
    private string collisionTag;


    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeNoseDirection();
        ChangePosition();
        Shot();
    }

    public void InitEnemyGun()
    {
        gun = gameObject.AddComponent<EnemyFirstTypeGun>();
    }

    public void Init(LevelMainScript mainLevel)
    {
        InitEnemyGun();
        randomizer = new System.Random();

        if (!destroyedFirstEnemyPrefab)
            destroyedFirstEnemyPrefab = Resources.Load<GameObject>("Levels/First/Prefabs/destroyedFirstEnemy");

        level = mainLevel;
        shuttle = mainLevel.shuttle;
        healPoints = EnemyFirstTypeConstants.HealPoints;
        scorePointsForReward = EnemyFirstTypeConstants.ScorePoints;
        StartCoroutine(gun.EnemyShot());
    }

    protected override void ChangeNoseDirection()
    {
        Vector2 direction = new Vector2(
            shuttle.transform.position.x - transform.position.x,
            shuttle.transform.position.y - transform.position.y
        );

        transform.up = direction;
    }

    // перемещение врага
    protected override void ChangePosition()
    {
        distanceToPlayer = Vector3.Distance(transform.position, shuttle.transform.position);

        // Если расстояние меньше или равно stopDistance, прекратим движение
        if (distanceToPlayer <= EnemyFirstTypeConstants.StopDistanceFolow) return;

        // Вычисляем направление к игроку
        Vector3 direction = shuttle.transform.position - transform.position;

        direction.Normalize();

        // Двигаем врага в направлении игрока
        transform.position += direction * EnemyFirstTypeConstants.Speed * Time.deltaTime;
    }

    protected override void additionalDecreasingHealPoints()
    {
        if (!isAlive)
        {
            if (randomizer.NextDouble() < DestroyedFirstEnemyConstants.ChanseToSpawn)
            {
                destroyedFirstEnemyObject = Instantiate(destroyedFirstEnemyPrefab, gameObject.transform.position, Quaternion.identity);
                destroyedFirstEnemyObject.GetComponent<DestroyedFirstEnemy>().Init(level);
            }
        }
    }

    // void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    // {
    //     collisionTag = collision.gameObject.tag;
    //
    //     collisionObject = collision.gameObject;
    //
    //     if (collisionTag != "bullet")
    //         Debug.Log(collisionTag);
    // }
    //
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     collisionTag = collision.gameObject.tag;
    //
    //     collisionObject = collision.gameObject;
    //
    //     if (collisionTag != "bullet")
    //         Debug.Log(collisionTag);
    // }

}
