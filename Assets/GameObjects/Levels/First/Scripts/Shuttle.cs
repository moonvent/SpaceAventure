using System.Collections;
using System.Collections.Generic;
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

    // префаб шатла
    private GameObject ShuttlePrefab;

    // объект шатла
    private GameObject shuttle;

    // объект пушки шатла
    private Gun gun;

    private void LoadPrefabs()
    {
        ShuttlePrefab = Resources.Load<GameObject>("Levels/First/Prefabs/shuffle_v2");
    }

    // задаем первисчные параметры для класса
    private void Awake()
    {
        LoadPrefabs();
        Debug.Log("shuttle created");
        shuttle = Instantiate(ShuttlePrefab);
        gun = shuttle.AddComponent<Gun>();
    }

    // поворот шатла
    private void RotateShuttle(float newRotateMultiplier)
    {
        shuttle.transform.Rotate(new Vector3(0, RotateValue * newRotateMultiplier, 0) * Time.deltaTime);
    }

    // удержание носа шатла
    private void ChangeNoseDirection()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // Convert the mouse position to world coordinates

        Vector2 direction = new Vector2(
            mousePosition.x - shuttle.transform.position.x,
            mousePosition.y - shuttle.transform.position.y
        );

        shuttle.transform.up = direction;
    }

    // перемещение шатла
    private void ChangeShuttlePosition()
    {
        Vector3 position = shuttle.transform.position;

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

        shuttle.transform.position = position;

    }

    // выстрел шатла
    private void ShotFromShuttle()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gun.Shot(shuttle.transform);
        }

    }

    void Update()
    {
        ChangeNoseDirection();
        ChangeShuttlePosition();
        ShotFromShuttle();
    }
}
