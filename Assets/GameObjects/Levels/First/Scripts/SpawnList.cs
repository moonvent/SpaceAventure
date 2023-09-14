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
    private Dictionary<float, GameObject> spawnRateWithEnemy;

    // рандомайзер
    private System.Random randomizer;

    // следующий шанс на спавн чего-либо
    private float nextSpawnRate;

    // сто процентов заспавненный враг
    private GameObject spawnEnemy;


    public SpawnList()
    {
        randomizer = new System.Random();
        InitEnemyPrefabs();
        FillSpawnRates();
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

    private void CreateNewSpawnRateWithEnemy()
    {
        spawnRateWithEnemy = new Dictionary<float, GameObject>();
    }

    private Dictionary<float, GameObject> CreateNewSpawnRateFirstStage()
    {
        CreateNewSpawnRateWithEnemy();
        spawnRateWithEnemy.Add(.99f, cachedEnemyPrefabs[EnemyLevelBehaviorConstant.EnemyType.First]);
        return spawnRateWithEnemy;
    }

    private Dictionary<float, GameObject> CreateNewSpawnRateSecondStage()
    {
        CreateNewSpawnRateWithEnemy();
        spawnRateWithEnemy.Add(.4f, cachedEnemyPrefabs[EnemyLevelBehaviorConstant.EnemyType.First]);
        spawnRateWithEnemy.Add(.6f, cachedEnemyPrefabs[EnemyLevelBehaviorConstant.EnemyType.Second]);
        return spawnRateWithEnemy;
    }

    private void FillSpawnRates()
    {
        spawnRates = new Dictionary<LevelStages, Dictionary<float, GameObject>>
        {
            // { LevelStages.First, CreateNewSpawnRateFirstStage() },
            { LevelStages.First, CreateNewSpawnRateSecondStage() },
            { LevelStages.Second, CreateNewSpawnRateSecondStage() }
        };
    }

    public GameObject GetEnemyForCurrentStage(LevelStages levelStage)
    {
        spawnRateWithEnemy = spawnRates[levelStage];
        nextSpawnRate = (float)randomizer.NextDouble();

        foreach (KeyValuePair<float, GameObject> spawnRate in spawnRateWithEnemy)
        {
            Debug.Log(nextSpawnRate);
            if (spawnRate.Key > nextSpawnRate)
            {
                return spawnRate.Value;
            }
            spawnEnemy = spawnRate.Value;

        }
        return spawnEnemy;
    }
}
