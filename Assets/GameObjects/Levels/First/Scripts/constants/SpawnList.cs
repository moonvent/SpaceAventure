public static class SpawnListContants
{
    // с какой частотой проверять новую стадию
    public static int stepToUpStage = 10;
}


// все фазы в первом уровне
public enum LevelStages
{
    First = 30,
    Second = 60,
    Third = 90,
    Four = 100,
}


// ключи к которым привязан спавн врагов
public enum EnemiesKeysForSpawn
{
    First, // EnemyFirstType
    Second, // EnemySecondType
}

