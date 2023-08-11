using UnityEngine;


public class EnemyFirstType : SpaceFlyObject
{
    // обхект который нужно приследовать
    private Shuttle shuttle;

    // расстояние до игрока
    private float distanceToPlayer;

    void Awake()
    {
    }

    protected EnemyFirstTypeGun gun;

    public void InitEnemyGun()
    {
        gun = gameObject.AddComponent<EnemyFirstTypeGun>();
    }

    public void Init(Shuttle levelShuttle)
    {
        InitEnemyGun();
        shuttle = levelShuttle;
        healPoints = EnemyFirstTypeConstants.HealPoints;
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

    // перемещение шатла
    protected override void ChangePosition()
    {
        distanceToPlayer = Vector3.Distance(transform.position, shuttle.transform.position);

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
