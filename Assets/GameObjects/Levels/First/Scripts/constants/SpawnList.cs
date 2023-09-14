using System.Collections.Generic;

public static class SpawnListContants
{
    // с какой частотой проверять новую стадию
    public const int stepToUpStage = 10;

    public static readonly Dictionary<(LevelStages, float), EnemyLevelBehaviorConstant.EnemyType> StageWithSpawnRate = new Dictionary<(LevelStages, float), EnemyLevelBehaviorConstant.EnemyType>
    {
        { (LevelStages.First, .99f), EnemyLevelBehaviorConstant.EnemyType.First},
        { (LevelStages.Second, .4f), EnemyLevelBehaviorConstant.EnemyType.First},
        { (LevelStages.Second, .6f), EnemyLevelBehaviorConstant.EnemyType.Second},
    };
}


// все фазы в первом уровне
public enum LevelStages
{
    First = 30,
    Second = 60,
    Third = 90,
    Four = 100,
}

