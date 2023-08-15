using UnityEngine;


public class EnemyFirstType : SpaceFlyObject
{
    // обхект который нужно приследовать
    private Shuttle shuttle;

    // расстояние до игрока
    private float distanceToPlayer;

    protected EnemyFirstTypeGun gun;

    public void InitEnemyGun()
    {
        gun = gameObject.AddComponent<EnemyFirstTypeGun>();
    }

    public void Init(LevelMainScript mainLevel)
    {
        InitEnemyGun();
        level = mainLevel;
        shuttle = mainLevel.shuttle;
        healPoints = EnemyFirstTypeConstants.HealPoints;
        scorePoints = EnemyFirstTypeConstants.ScorePoints;
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

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeNoseDirection();
        ChangePosition();
        Shot();
    }
}
