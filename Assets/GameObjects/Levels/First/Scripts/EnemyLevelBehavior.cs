using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyLevelBehavior : MonoBehaviour
{
    // объект врага первого типа
    private GameObject enemyPrefab;

    private Dictionary<EnemyLevelBehaviorConstant.EnemyType, GameObject> cachedEnemyPrefabs;

    // временный объект врага 
    private EnemyFirstType enemyFirstType;

    // теущее состояние камеры
    private Camera mainCamera;

    // позиция спавна врага
    private Vector2 enemySpawnPosition;

    // стороны для спавна
    private LevelMainScriptConstant.SpawnSides[] spawnSides;

    // сторона на которой заспавнится враг
    private LevelMainScriptConstant.SpawnSides spawnSide;

    // главный цикл уровня
    private LevelMainScript mainLevel;

    // объект рандома
    private System.Random random;

    // рандомные точки спавна
    private float randomYPointSpawn;
    private float randomXPointSpawn;

    // текущая стадия в уровне
    private LevelStages currentStage;

    // кешированный тип Фаз 
    private Type levelStagesType;

    // Определить границы камеры
    float halfHeight;
    float halfWidth;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // координаты спавна врага
    float spawnX;
    float spawnY;

    /// начало спавна врагов
    public void Init(LevelMainScript level)
    {
        mainLevel = level;

        mainCamera = Camera.main;

        halfHeight = mainCamera.orthographicSize;
        halfWidth = mainCamera.aspect * halfHeight;
        xMin = mainCamera.transform.position.x - halfWidth;
        xMax = mainCamera.transform.position.x + halfWidth;
        yMin = mainCamera.transform.position.y - halfHeight;
        yMax = mainCamera.transform.position.y + halfHeight;

        levelStagesType = typeof(LevelStages);
        currentStage = LevelStages.First;

        random = new System.Random();

        enemyFirstType = LoadEnemyFirstType();

        spawnSides = (LevelMainScriptConstant.SpawnSides[])Enum.GetValues(typeof(LevelMainScriptConstant.SpawnSides));

        cachedEnemyPrefabs = new Dictionary<EnemyLevelBehaviorConstant.EnemyType, GameObject>
        {
            {EnemyLevelBehaviorConstant.EnemyType.First, Resources.Load<GameObject>("Levels/First/Prefabs/enemy")},
            {EnemyLevelBehaviorConstant.EnemyType.Second, Resources.Load<GameObject>("Levels/First/Prefabs/enemy")},
        };

        StartCoroutine(SpawnEnemy());
    }

    /// смена волны врагов
    private void ChangeEnemyStage()
    {

    }

    public void SwitchStage(int score)
    {
        if (CheckNewStage(score))
        {
            if (Enum.IsDefined(levelStagesType, score))
            {
                currentStage = (LevelStages)score;
                // ChangeEnemyStage();
            }
        }
    }

    /// проверка новой стадии врагов
    private bool CheckNewStage(int score)
    {
        return score % SpawnListContants.stepToUpStage == 0;
    }

    private EnemyFirstType LoadEnemyFirstType()
    {
        if (!enemyPrefab)
            enemyPrefab = Resources.Load<GameObject>("Levels/First/Prefabs/enemy");
        return enemyPrefab.GetComponent<EnemyFirstType>();
    }

    private Vector2 CalculateSpawnPoint()
    {
        // Выбрать позицию за пределами видимой области
        spawnSide = spawnSides[random.Next(spawnSides.Length)];

        randomYPointSpawn = yMin + (float)random.NextDouble() * yMax;
        randomXPointSpawn = xMin + (float)random.NextDouble() * xMax;

        switch (spawnSide)
        {
            case LevelMainScriptConstant.SpawnSides.Left:
                spawnX = xMin - 1;
                spawnY = randomYPointSpawn;
                break;
            case LevelMainScriptConstant.SpawnSides.Right:
                spawnX = xMax + 1;
                spawnY = randomYPointSpawn;
                break;
            case LevelMainScriptConstant.SpawnSides.Up:
                spawnX = randomXPointSpawn;
                spawnY = yMin - 1;
                break;
            case LevelMainScriptConstant.SpawnSides.Down:
                spawnX = randomXPointSpawn;
                spawnY = yMax + 1;
                break;
        }
        // Создать экземпляр объекта на выбранной позиции
        enemySpawnPosition = new Vector2(spawnX, spawnY);

        return enemySpawnPosition;
    }

    IEnumerator SpawnEnemy()
    {
        // This is an infinite loop, be careful with these!
        while (true)
        {
            // This instantiates a new object at the position (0, 0, 0) with no rotation
            GameObject newEnemy = Instantiate(enemyPrefab, CalculateSpawnPoint(), Quaternion.identity);
            newEnemy.GetComponent<EnemyFirstType>().Init(mainLevel);

            // This pauses the Coroutine for 1 second
            yield return new WaitForSeconds(1f);
        }
    }

}
