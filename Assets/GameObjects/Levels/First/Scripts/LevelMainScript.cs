using System.Collections;
using System;
using UnityEngine;
using TMPro;


public class LevelMainScript : MonoBehaviour
{

    // объект коробля
    public Shuttle shuttle;

    // объект врага первого типа
    private GameObject enemyPrefab;

    // временный объект врага 
    private EnemyFirstType enemyFirstType;

    // позиция спавна врага
    private Vector2 enemySpawnPosition;

    // теущее состояние камеры
    private Camera mainCamera;

    // стороны для спавна
    private LevelMainScriptConstant.SpawnSides[] spawnSides;

    // сторона на которой заспавнится враг
    private LevelMainScriptConstant.SpawnSides spawnSide;

    // объект рандома
    private System.Random random;

    // рандомные точки спавна
    private float randomYPointSpawn;
    private float randomXPointSpawn;

    private TMP_Text scoreText;
    private TMP_Text hpText;

    // счёт уровня
    private int _Score;

    // интерфейс
    private GameObject uiCanvas;

    // текущая стадия в уровне
    private LevelStages currentStage;

    // кешированный тип Фаз 
    private Type levelStagesType;

    // количество убийств
    public int Score
    {
        get
        {
            return _Score;
        }
        set
        {
            _Score = value;
            scoreText.text = string.Format(LevelMainScriptConstant.ScoreText, Score);

            if (_Score % SpawnListContants.stepToUpStage == 0)
            {
                if (Enum.IsDefined(levelStagesType, _Score))
                {
                    currentStage = (LevelStages)_Score;
                    Debug.Log(currentStage);
                }
            }

        }
    }

    private void LoadShuttle()
    {
        GameObject ShuttlePrefab = Instantiate(Resources.Load<GameObject>("Levels/First/Prefabs/shuffle_v2"));
        shuttle = ShuttlePrefab.GetComponent<Shuttle>();
        shuttle.Init(hpText);
    }

    private EnemyFirstType LoadEnemyFirstType()
    {
        if (!enemyPrefab)
            enemyPrefab = Resources.Load<GameObject>("Levels/First/Prefabs/enemy");
        return enemyPrefab.GetComponent<EnemyFirstType>();
    }

    private void Init()
    {

        Debug.Log("level script awake");
        uiCanvas = GameObject.Find("UiCanvas");
        TMP_Text[] uiTexts = uiCanvas.GetComponentsInChildren<TMP_Text>();
        scoreText = uiTexts[0];
        hpText = uiTexts[1];

        levelStagesType = typeof(LevelStages);
        currentStage = LevelStages.First;

        Score = 0;

        LoadShuttle();
        enemyFirstType = LoadEnemyFirstType();
        mainCamera = Camera.main;
        spawnSides = (LevelMainScriptConstant.SpawnSides[])Enum.GetValues(typeof(LevelMainScriptConstant.SpawnSides));
        random = new System.Random();
    }


    void Awake()
    {
        Init();
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


    private Vector2 CalculateSpawnPoint()
    {
        // Определить границы камеры
        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = mainCamera.aspect * halfHeight;
        float xMin = mainCamera.transform.position.x - halfWidth;
        float xMax = mainCamera.transform.position.x + halfWidth;
        float yMin = mainCamera.transform.position.y - halfHeight;
        float yMax = mainCamera.transform.position.y + halfHeight;

        // Выбрать позицию за пределами видимой области
        spawnSide = spawnSides[random.Next(spawnSides.Length)];

        randomYPointSpawn = yMin + (float)random.NextDouble() * yMax;
        randomXPointSpawn = xMin + (float)random.NextDouble() * xMax;

        switch (spawnSide)
        {
            case LevelMainScriptConstant.SpawnSides.Left:
                enemySpawnPosition = new Vector2(xMin - 1, randomYPointSpawn);
                break;
            case LevelMainScriptConstant.SpawnSides.Right:
                enemySpawnPosition = new Vector2(xMax + 1, randomYPointSpawn);
                break;
            case LevelMainScriptConstant.SpawnSides.Up:
                enemySpawnPosition = new Vector2(randomXPointSpawn, yMin - 1);
                break;
            case LevelMainScriptConstant.SpawnSides.Down:
                enemySpawnPosition = new Vector2(randomXPointSpawn, yMax + 1);
                break;
        }

        // Создать экземпляр объекта на выбранной позиции
        return enemySpawnPosition;
    }

    IEnumerator SpawnEnemy()
    {
        // This is an infinite loop, be careful with these!
        while (true)
        {
            // This instantiates a new object at the position (0, 0, 0) with no rotation
            GameObject newEnemy = Instantiate(enemyPrefab, CalculateSpawnPoint(), Quaternion.identity);
            newEnemy.GetComponent<EnemyFirstType>().Init(this);

            // This pauses the Coroutine for 1 second
            yield return new WaitForSeconds(1f);
        }
    }

}
