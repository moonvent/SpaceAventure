using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnList
{

    private Dictionary<float, Entity> entitiesOnLevel;
    private Dictionary<LevelStages, Dictionary<float, Entity>> spawnRates;

    // public SpawnList()
    // {
    //     spawnRates = new Dictionary<LevelStages, Dictionary<float, Entity>>();
    // }
    //
    // private GameObject CreateEntity(EnemiesKeysForSpawn key)
    // {
    //     switch (key)
    //     {
    //         case EnemiesKeysForSpawn.First:
    //             return Instantiate(enemyPrefab, CalculateSpawnPoint(), Quaternion.identity);
    //     }
    // }
    //
    // private void AddEnemiesToSpawnRates()
    // {
    //     entitiesOnLevel.Add(1.0f, () => CreateEntity(EnemiesKeysForSpawn.First));
    //     spawnRates.Add(LevelStages.First, entitiesOnLevel);
    // }
    //
    // public GameObject CreateNewEnemy()
    // {
    //     entitiesOnLevel;
    // }

}
