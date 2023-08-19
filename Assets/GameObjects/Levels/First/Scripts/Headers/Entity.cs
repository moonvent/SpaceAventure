using UnityEngine;


/// <summary>
/// Класс сущности, пока что нужно для подсчёта кол-ва хп
/// </summary>
public class Entity : MonoBehaviour
{
    // сколько поинтов за победу над объектом
    protected int scorePointsForReward;

    // объект уровня, для более удобной работы с объектом уровня
    protected LevelMainScript level;

    // если объект должен хилить, то эта перменная насколько он должен хилить
    public int healedPoints;

    // что происходит после уничтожения объекта
    protected void ObjectDestroied()
    {
        level.Score += scorePointsForReward;
    }

    // кол-во хп у объекта
    protected int healPoints = 3;

    // жив объект или мертв
    protected bool isAlive = true;

    /// <summary>
    /// Функция которая уменьшает кол-во хп, и если оно ниже нуля, меняет статус и удаляет объект
    /// </summary>
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

        additionalDecreasingHealPoints();
    }

    /// <summary>
    /// Дополнительная функция, которая вызывается когда уменьшается хп
    /// </summary>
    protected virtual void additionalDecreasingHealPoints()
    {

    }
}
