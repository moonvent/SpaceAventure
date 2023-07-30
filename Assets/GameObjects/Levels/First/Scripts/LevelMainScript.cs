using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelMainScript : MonoBehaviour
{

    // объект коробля
    private Shuttle shuttle;

    // список пуль
    private BulletList bulletList;

    void Awake()
    {
        Debug.Log("level script awake");
        shuttle = gameObject.AddComponent<Shuttle>();
        bulletList = gameObject.AddComponent<BulletList>();
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
