using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Описание интерфейса летающих объектов
/// </summary>
public abstract class SpaceFlyObject : Entity
{
    /// <summary>
    /// Инициализация объекта
    /// </summary>
    public abstract void Init();
    public abstract void Init(Shuttle levelShuttle);

    /// <summary>
    /// Смена курса объекта, а именно его носовой части
    /// </summary>
    protected abstract void ChangeNoseDirection();

    /// <summary>
    /// Смена местаположения объекта
    /// </summary>
    protected abstract void ChangePosition();

    /// <summary>
    /// Выстрел из объекта
    /// </summary>
    protected abstract void Shot();
}
