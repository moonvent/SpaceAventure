using UnityEngine;


public class EnemyFirstType : SpaceFlyEnemyFirstType
{
    // обхект который нужно приследовать
    private Shuttle shuttle;

    // расстояние до игрока
    private float distanceToPlayer;

    void Awake()
    {
    }

    public override void Init(Shuttle levelShuttle)
    {
        shuttle = levelShuttle;
        healPoints = ShuttleConstants.ShuttleHealPoints;
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

    protected override void Shot()
    {
        // gun.Shot();
    }
}
