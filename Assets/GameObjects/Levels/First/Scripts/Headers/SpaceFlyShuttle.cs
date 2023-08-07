
public class SpaceFlyShuttle : SpaceFlyObject
{
    // пушка объекта
    protected ShuttleGun gun;

    /// <summary>
    /// Инициализация объекта
    /// </summary>
    public virtual void Init()
    {
        gun = gameObject.AddComponent<ShuttleGun>();
    }

}
