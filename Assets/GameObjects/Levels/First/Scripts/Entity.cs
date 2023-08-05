using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Класс сущности, пока что нужно для подсчёта кол-ва хп
/// </summary>
public class Entity : MonoBehaviour
{

    protected int healPoints = 3;

    private bool isAlive;

    public void descreaseHealPoints(int decreaseValue)
    {
        healPoints -= decreaseValue;
        Debug.Log(healPoints);

        if (healPoints <= 0)
        {
            isAlive = false;
            // throw new EntityIsDead();
            Destroy(gameObject);
        }
    }
}
