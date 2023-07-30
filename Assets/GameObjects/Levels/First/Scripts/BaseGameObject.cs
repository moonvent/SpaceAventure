// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
//
// public class BaseGameObject : MonoBehaviour
// {
//     // величина на которую будет поворачиваться за единицу времени
//     private const float rotateValue = 180f;
//
//     // текущее значение угла поворота
//     private float currentRotationAngle;
//
//     // погрешность при повороте (иногда может повернуться чуть больше)
//     private const float uncertaintyAngle = 2f;
//
//     // максимальный угол на который можно повернуть
//     private const float maxRotateAngleByAxel = 360f;
//
//     // максимальный угол на который можно повернуть на право
//     private const float maximalRotateToRightAngle = 45f;
//
//     // максимальный угол на который можно повернуть на лево
//     private const float maximalRotateToLeftAngle = maxRotateAngleByAxel - maximalRotateToRightAngle;
//
//     // макисамльный угол поворота направо с погрешностью
//     private const float maximalRotateToRightAngleWithUncertaintly = maximalRotateToRightAngle + uncertaintyAngle;
//
//     // минимальный угол поворота налево с погрешностью
//     private const float maximalRotateToLeftAngleWithUncertaintly = maximalRotateToLeftAngle - uncertaintyAngle;
//
//     // рассчёт порешности для выравнивания правого поворота (чтоб оп инерции он достиг центра и остановился)
//     private const float uncertaintyLeftAngle = maxRotateAngleByAxel - uncertaintyAngle;
//
//     // 2 значения куда поворачивать, влево или вправо
//     private const float RotateRight = 1;
//     private const float RotateLeft = -1;
//
//     // куда поворачивать объект, влево или вправо, может быть знаение только RotateLeft или RotateRight
//     private float rotateTo = 0;
//
//     // если ли инерция при повороте обратно, после поворота ставим тру, когда выровнялись - фалс
//     private bool backInertion = false;
//
//     private bool upButtonPressed = false;
//     private bool downButtonPressed = false;
//     private bool leftButtonPressed = false;
//     private bool rightButtonPressed = false;
//
//     // префаб пули
//     public GameObject bulletPrefab;
//
//     // скорость пули
//     private const float bulletSpeed = 15f;
//
//     // префаб врага
//     public GameObject enemyPrefab;
//
//     // скорость пули
//     private const float enemySpeed = 5f;
//
//     void Start()
//     {
//         StartCoroutine(SpawnEnemy());
//     }
//
//
//     private void rotateShuttle(float newRotateMultiplier)
//     {
//         transform.Rotate(new Vector3(0, rotateValue * newRotateMultiplier, 0) * Time.deltaTime);
//     }
//
//
//     private void changeUpDirection()
//     {
//
//         Vector3 mousePosition = Input.mousePosition;
//         mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // Convert the mouse position to world coordinates
//
//         Vector2 direction = new Vector2(
//             mousePosition.x - transform.position.x,
//             mousePosition.y - transform.position.y
//         );
//
//         transform.up = direction;
//     }
//
//     private void changeShuttlePosition()
//     {
//         float speed = 5f;
//
//         Vector3 position = transform.position;
//
//         currentRotationAngle = transform.rotation.eulerAngles.y;
//
//         upButtonPressed = Input.GetKey(KeyCode.W);
//         downButtonPressed = Input.GetKey(KeyCode.S);
//         leftButtonPressed = Input.GetKey(KeyCode.A);
//         rightButtonPressed = Input.GetKey(KeyCode.D);
//
//         // Vector3 mousePosition = Input.mousePosition;
//         // mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // Convert the mouse position to world coordinates
//         //
//         // if (upButtonPressed || downButtonPressed)
//         // {
//         //     // if (upButtonPressed)
//         //     //     position += transform.up / 1.25f * speed * Time.deltaTime;
//         //     // else
//         //     //     position -= transform.up / 1.25f * speed * Time.deltaTime;
//         //
//         //     position += (upButtonPressed ? 1 : -1) * transform.up / 1.15f * speed * Time.deltaTime;
//         // }
//         // if (rightButtonPressed || leftButtonPressed)
//         // {
//         //     // position.x += (rightButtonPressed ? 1 : -1) * speed * Time.deltaTime;
//         //     position += (rightButtonPressed ? 1 : -1) * transform.right * speed * Time.deltaTime;
//         // }
//
//         if (upButtonPressed || downButtonPressed)
//         {
//             position.y += (upButtonPressed ? 1 : -1) * speed * Time.deltaTime;
//         }
//         if (rightButtonPressed || leftButtonPressed)
//         {
//             position.x += (rightButtonPressed ? 1 : -1) * speed * Time.deltaTime;
//         }
//
//         transform.position = position;
//
//     }
//
//     IEnumerator SpawnEnemy()
//     {
//         // This is an infinite loop, be careful with these!
//         while (true)
//         {
//             // This instantiates a new object at the position (0, 0, 0) with no rotation
//             Instantiate(enemyPrefab, new Vector2(0, 0), Quaternion.identity);
//
//             // This pauses the Coroutine for 1 second
//             yield return new WaitForSeconds(5f);
//         }
//     }
//
//
//     private void shotFromShuttle()
//     {
//         if (Input.GetKey(KeyCode.Space))
//         {
//             GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.up / 2.25f, transform.rotation);
//
//             // Add velocity to the bullet
//             bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
//
//             // Destroy the bullet after 2 seconds
//             Destroy(bullet, 1.0f);
//         }
//
//     }
//
//
//
//     void Update()
//     {
//         changeUpDirection();
//         changeShuttlePosition();
//         shotFromShuttle();
//     }
// }
