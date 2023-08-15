using UnityEngine;


public class Shuttle : SpaceFlyObject
{

    // пушка объекта
    protected ShuttleGun gun;

    // скорость шатла
    private const float ShuttleMovementSpeed = 5f;

    // значение для скорости поворота коробля
    private const float RotateValue = 180f;

    private bool upButtonPressed = false;
    private bool downButtonPressed = false;
    private bool leftButtonPressed = false;
    private bool rightButtonPressed = false;

    // объект шатла
    private GameObject shuttle;

    // задаем первичные параметры для класса
    void Awake()
    {
        Init();
    }

    void FixedUpdate()
    {
        ChangeNoseDirection();
        ChangePosition();
        Shot();
    }

    public void Init()
    {
        Debug.Log("shuttle created");
        scorePoints = 0;
        gun = gameObject.AddComponent<ShuttleGun>();
        healPoints = ShuttleConstants.ShuttleHealPoints;
    }

    // удержание носа шатла
    protected override void ChangeNoseDirection()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // Convert the mouse position to world coordinates

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }

    // перемещение шатла
    protected override void ChangePosition()
    {
        Vector3 position = transform.position;

        upButtonPressed = Input.GetKey(KeyCode.W);
        downButtonPressed = Input.GetKey(KeyCode.S);
        leftButtonPressed = Input.GetKey(KeyCode.A);
        rightButtonPressed = Input.GetKey(KeyCode.D);

        if (upButtonPressed || downButtonPressed)
        {
            position.y += (upButtonPressed ? 1 : -1) * ShuttleMovementSpeed * Time.deltaTime;
        }
        if (rightButtonPressed || leftButtonPressed)
        {
            position.x += (rightButtonPressed ? 1 : -1) * ShuttleMovementSpeed * Time.deltaTime;
        }

        transform.position = position;

    }

    // выстрел шатла
    protected override void Shot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gun.Shot();
        }

    }
}
