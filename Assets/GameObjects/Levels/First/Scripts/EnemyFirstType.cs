using UnityEngine;


public class EnemyFirstType : SpaceFlyObject
{
    // обхект который нужно приследовать
    private Shuttle shuttle;

    // пушка объекта
    private Gun gun;

    // расстояние до игрока
    private float distanceToPlayer;

    void Awake()
    {
    }

    public override void Init(Shuttle levelShuttle)
    {
        shuttle = levelShuttle;
        healPoints = ShuttleConstants.ShuttleHealPoints;
        gun = gameObject.AddComponent<Gun>();
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
    }

    public override void Init()
    {
        throw new System.NotImplementedException();
    }

    protected override void Shot()
    {
        throw new System.NotImplementedException();
    }
}
