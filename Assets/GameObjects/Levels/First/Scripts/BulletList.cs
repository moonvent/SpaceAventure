using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletList : MonoBehaviour
{
    public static BulletList Instance { get; private set; }

    private List<Bullet> bulletList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            bulletList = new List<Bullet>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Add(Bullet bullet)
    {
        Debug.Log(bullet);
        // bulletList.Add(bullet);
    }
}
