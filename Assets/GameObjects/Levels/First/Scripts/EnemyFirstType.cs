using UnityEngine;


public class EnemyFirstType : Enemy
{
    void FixedUpdate()
    {
        ChangeNoseDirection();
        ChangePosition();
    }

    public override void InitEnemyGun()
    {
        gun = gameObject.AddComponent<EnemyFirstTypeGun>();
    }

    public void Init(LevelMainScript mainLevel)
    {
        base.Init(mainLevel);

        healPoints = EnemyFirstTypeConstants.HealPoints;
        scorePointsForReward = EnemyFirstTypeConstants.ScorePoints;

        destroyedEnemyPrefab = Resources.Load<GameObject>("Levels/First/Prefabs/destroyedFirstEnemy");

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
                destroyedEnemyObject = Instantiate(destroyedEnemyPrefab, gameObject.transform.position, Quaternion.identity);
                destroyedEnemyObject.GetComponent<DestroyedFirstEnemy>().Init(level);
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
