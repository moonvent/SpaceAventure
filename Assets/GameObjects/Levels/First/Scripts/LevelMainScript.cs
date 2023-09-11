using System.Collections;
using System;
using UnityEngine;
using TMPro;


public class LevelMainScript : MonoBehaviour
{

    // объект коробля
    public Shuttle shuttle;

    private TMP_Text scoreText;
    private TMP_Text hpText;

    // счёт уровня
    private int _Score;

    // интерфейс
    private GameObject uiCanvas;

    // модуль управления врагами
    private EnemyLevelBehavior enemyLevelBehavior;

    // количество убийств
    public int Score
    {
        get
        {
            return _Score;
        }
        set
        {
            _Score = value;
            scoreText.text = string.Format(LevelMainScriptConstant.ScoreText, Score);

            enemyLevelBehavior.SwitchStage(_Score);
        }
    }

    private void LoadShuttle()
    {
        GameObject ShuttlePrefab = Instantiate(Resources.Load<GameObject>("Levels/First/Prefabs/shuffle_v2"));
        shuttle = ShuttlePrefab.GetComponent<Shuttle>();
        shuttle.Init(hpText);
    }

    private void Init()
    {

        Debug.Log("level script awake");
        uiCanvas = GameObject.Find("UiCanvas");
        TMP_Text[] uiTexts = uiCanvas.GetComponentsInChildren<TMP_Text>();
        scoreText = uiTexts[0];
        hpText = uiTexts[1];

        LoadShuttle();

        enemyLevelBehavior = gameObject.AddComponent<EnemyLevelBehavior>();
        enemyLevelBehavior.Init(this);

        Score = 0;
    }


    void Awake()
    {
        Init();
    }
}
