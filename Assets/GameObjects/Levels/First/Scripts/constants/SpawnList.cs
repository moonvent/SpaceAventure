using System.Collections.Generic;

public static class SpawnListContants
{
    // с какой частотой проверять новую стадию
    public const int stepToUpStage = 10;

    public static readonly Dictionary<LevelStages, List<(float, EnemyLevelBehaviorConstant.EnemyType)>> StageWithSpawnRate = new Dictionary<LevelStages, List<(float, EnemyLevelBehaviorConstant.EnemyType)>>
    {
        { LevelStages.First, new List<(float, EnemyLevelBehaviorConstant.EnemyType)>
            {
                (1f, EnemyLevelBehaviorConstant.EnemyType.First),
            }
        },
        { LevelStages.Second, new List<(float, EnemyLevelBehaviorConstant.EnemyType)>
            {
                (.3f, EnemyLevelBehaviorConstant.EnemyType.First),
                (.7f, EnemyLevelBehaviorConstant.EnemyType.Second)
            }
        },
    };
}


// все фазы в первом уровне
public enum LevelStages
{
    First = 0,
    Second = 30,
    Third = 60,
    Four = 90,
    Fifth = 100,
}

