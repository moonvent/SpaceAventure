using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// описание общего объекта врага
public abstract class Enemy : SpaceFlyObject
{
    // объект который нужно приследовать
    protected Shuttle shuttle;

    // расстояние до игрока
    protected float distanceToPlayer;

    protected Gun gun;

    // префаб разрушенного врага 
    protected GameObject destroyedEnemyPrefab;

    // объект разрушенного врага
    protected GameObject destroyedEnemyObject;

    // рандомайзер для будущих нужд
    protected System.Random randomizer;

    public abstract void InitEnemyGun();

    public void Init(LevelMainScript mainLevel)
    {
        InitEnemyGun();
        randomizer = new System.Random();

        level = mainLevel;
        shuttle = mainLevel.shuttle;
    }

}
