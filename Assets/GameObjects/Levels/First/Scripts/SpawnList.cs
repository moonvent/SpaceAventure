using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnList
{
    // кешированные префабы + названия самих врагов
    private Dictionary<EnemyLevelBehaviorConstant.EnemyType, GameObject> cachedEnemyPrefabs;

    // описание этапа, подкрепление к нему шанса спавна и врага
    private Dictionary<LevelStages, Dictionary<float, GameObject>> spawnRates;

    // описание шанса спавна и врага на одном из этапов
    private List<(float, EnemyLevelBehaviorConstant.EnemyType)> spawnRateWithEnemy;

    // рандомайзер
    private System.Random randomizer;

    // следующий шанс на спавн чего-либо
    private float nextSpawnRate;

    // сто процентов заспавненный враг
    private EnemyLevelBehaviorConstant.EnemyType spawnEnemyKey;


    public SpawnList()
    {
        randomizer = new System.Random();
        InitEnemyPrefabs();
    }

    // инициализация вражеских префабов
    public void InitEnemyPrefabs()
    {
        cachedEnemyPrefabs = new Dictionary<EnemyLevelBehaviorConstant.EnemyType, GameObject>
        {
            {EnemyLevelBehaviorConstant.EnemyType.First, Resources.Load<GameObject>("Levels/First/Prefabs/enemy_v1")},
            {EnemyLevelBehaviorConstant.EnemyType.Second, Resources.Load<GameObject>("Levels/First/Prefabs/enemy_v2")},
        };
    }

    public GameObject GetEnemyForCurrentStage(LevelStages levelStage)
    {
        // Debug.Log(levelStage);
        spawnRateWithEnemy = SpawnListContants.StageWithSpawnRate[levelStage];
        nextSpawnRate = (float)randomizer.NextDouble();

        foreach (var (spawnRate, enemyTypeKey) in spawnRateWithEnemy)
        {
            if (spawnRate > nextSpawnRate)
            {
                spawnEnemyKey = enemyTypeKey;
                break;
            }
            spawnEnemyKey = enemyTypeKey;

        }
        return cachedEnemyPrefabs[spawnEnemyKey];

    }
}
