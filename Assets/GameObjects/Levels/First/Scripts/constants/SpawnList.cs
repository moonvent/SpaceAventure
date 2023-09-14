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
    First = 30,
    Second = 60,
    Third = 90,
    Four = 100,
}

