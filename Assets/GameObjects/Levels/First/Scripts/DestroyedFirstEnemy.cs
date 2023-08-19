public class DestroyedFirstEnemy : Entity
{
    public void Init(LevelMainScript mainLevel)
    {
        healPoints = DestroyedFirstEnemyConstants.HealPoints;
        scorePointsForReward = DestroyedFirstEnemyConstants.ScorePoints;
        level = mainLevel;
    }
}
