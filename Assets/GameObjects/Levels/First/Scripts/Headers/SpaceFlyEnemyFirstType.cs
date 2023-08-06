using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SpaceFlyEnemyFirstType : SpaceFlyObject
{
    protected EnemyFirstTypeGun gun;

    public virtual void Init(Shuttle levelShuttle)
    {
        gun = gameObject.AddComponent<EnemyFirstTypeGun>();
    }
}
