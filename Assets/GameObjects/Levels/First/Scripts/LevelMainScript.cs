using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelMainScript : MonoBehaviour
{

    // объект коробля
    private Shuttle shuttle;

    private Shuttle LoadShuttle()
    {
        GameObject ShuttlePrefab = Instantiate(Resources.Load<GameObject>("Levels/First/Prefabs/shuffle_v2"));
        return ShuttlePrefab.GetComponent<Shuttle>();
    }

    void Awake()
    {
        Debug.Log("level script awake");
        shuttle = LoadShuttle();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
