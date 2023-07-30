using UnityEngine;


public class Shuttle : MonoBehaviour
{
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

    // объект пушки шатла
    private Gun gun;

    // задаем первичные параметры для класса
    void Awake()
    {
        Debug.Log("shuttle created");
        gun = gameObject.AddComponent<Gun>();
    }


    // поворот шатла
    private void RotateShuttle(float newRotateMultiplier)
    {
        transform.Rotate(new Vector3(0, RotateValue * newRotateMultiplier, 0) * Time.deltaTime);
    }

    // удержание носа шатла
    private void ChangeNoseDirection()
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
    private void ChangeShuttlePosition()
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
    private void ShotFromShuttle()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gun.Shot(transform);
        }

    }

    void Update()
    {
        ChangeNoseDirection();
        ChangeShuttlePosition();
        ShotFromShuttle();
    }
}
