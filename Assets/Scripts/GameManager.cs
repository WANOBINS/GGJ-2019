using System;
using System.Collections.Generic;
using UnityEngine;
using WBase.Unity.Extensions;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Enemies { get; private set; } = new List<GameObject>();
    public List<GameObject> Gazebos { get; private set; } = new List<GameObject>();
    public List<GameObject> Houses { get; private set; } = new List<GameObject>();
    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(transform);
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        PurgeLists();
    }

    private void PurgeLists()
    {
        Enemies.PurgeNulls();
        Gazebos.PurgeNulls();
        Houses.PurgeNulls();
    }
}