using UnityEngine;


public class DestroyedFirstEnemy : Entity
{
    public void Init(LevelMainScript mainLevel)
    {
        healPoints = DestroyedFirstEnemyConstants.HealPoints;
        scorePointsForReward = DestroyedFirstEnemyConstants.ScorePoints;
        healedPoints = DestroyedFirstEnemyConstants.HealedPoints;
        level = mainLevel;
    }

}
