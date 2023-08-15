using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Класс сущности, пока что нужно для подсчёта кол-ва хп
/// </summary>
public class Entity : MonoBehaviour
{
    protected int scorePoints;

    protected LevelMainScript level;

    protected void ObjectDestroied()
    {
        level.score += scorePoints;
        Debug.Log(level.score);
    }

    protected int healPoints = 3;

    private bool isAlive;

    public void descreaseHealPoints(int decreaseValue)
    {
        healPoints -= decreaseValue;

        if (healPoints <= 0)
        {
            isAlive = false;
            // throw new EntityIsDead();
            Destroy(gameObject);
            ObjectDestroied();
        }
    }
}
