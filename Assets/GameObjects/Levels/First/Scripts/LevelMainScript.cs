using System.Collections;
using UnityEngine;


public class LevelMainScript : MonoBehaviour
{

    // объект коробля
    private Shuttle shuttle;

    // объект врага первого типа
    private GameObject enemyPrefab;

    // временный объект врага 
    private EnemyFirstType enemyFirstType;

    private Shuttle LoadShuttle()
    {
        GameObject ShuttlePrefab = Instantiate(Resources.Load<GameObject>("Levels/First/Prefabs/shuffle_v2"));
        return ShuttlePrefab.GetComponent<Shuttle>();
    }

    private EnemyFirstType LoadEnemyFirstType()
    {
        if (!enemyPrefab)
            enemyPrefab = Resources.Load<GameObject>("Levels/First/Prefabs/enemy");
        return enemyPrefab.GetComponent<EnemyFirstType>();
    }


    void Awake()
    {
        Debug.Log("level script awake");
        shuttle = LoadShuttle();
        enemyFirstType = LoadEnemyFirstType();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
    }

    IEnumerator SpawnEnemy()
    {
        // This is an infinite loop, be careful with these!
        while (true)
        {
            // This instantiates a new object at the position (0, 0, 0) with no rotation
            Debug.Log("spawn new");
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector2(0, 0), Quaternion.identity);
            newEnemy.GetComponent<EnemyFirstType>().Init(shuttle);

            // This pauses the Coroutine for 1 second
            yield return new WaitForSeconds(20f);
        }
    }

}
