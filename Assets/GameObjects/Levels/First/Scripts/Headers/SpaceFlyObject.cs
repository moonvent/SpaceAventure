
/// <summary>
/// Описание интерфейса летающих объектов
/// </summary>
public abstract class SpaceFlyObject : Entity
{
    /// <summary>
    /// Смена курса объекта, а именно его носовой части
    /// </summary>
    protected virtual void ChangeNoseDirection() { }

    /// <summary>
    /// Смена местаположения объекта
    /// </summary>
    protected virtual void ChangePosition() { }

    /// <summary>
    /// Выстрел из объекта
    /// </summary>
    protected virtual void Shot() { }
}
