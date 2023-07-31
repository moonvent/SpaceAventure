using System;
using UnityEngine;


public class EntityIsDead : Exception
{
    private const string message = "Entity is dead";
    public EntityIsDead()
    {
    }

    public EntityIsDead(string message)
        : base(message)
    {
    }

    public EntityIsDead(string message, Exception inner)
        : base(message, inner)
    {
    }
}
