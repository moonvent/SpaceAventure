using UnityEngine;
using TMPro;


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

    // объект с которым происходит коллизия
    private GameObject collisionObject;

    // сущность с которой происходит коллизия
    private Entity collisionEntity;

    // тег объекта с которым произошла коллизия
    private string collisionTag;

    // надпись о хпшках шатла
    private TMP_Text hpText;

    // новое кол-во хп после регенерации об что-то
    private int newHealPoints;

    void FixedUpdate()
    {
        ChangeNoseDirection();
        ChangePosition();
        Shot();
    }

    public void Init(TMP_Text levelHpText)
    {
        Debug.Log("shuttle created");
        scorePointsForReward = 0;
        gun = gameObject.AddComponent<ShuttleGun>();
        healPoints = ShuttleConstants.ShuttleHealPoints;
        hpText = levelHpText;
    }

    protected override void additionalDecreasingHealPoints()
    {
        hpText.text = string.Format(ShuttleConstants.HealPointText, healPoints);
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

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        collisionTag = collision.gameObject.tag;

        collisionObject = collision.gameObject;

        if (collisionTag == ShuttleConstants.DestroyedFirstTypeTag)
        {
            newHealPoints = healPoints + collision.gameObject.GetComponent<Entity>().healedPoints;
            if (newHealPoints <= ShuttleConstants.ShuttleHealPoints)
            {
              healPoints = newHealPoints;
              Destroy(collisionObject);
            }
        }

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
