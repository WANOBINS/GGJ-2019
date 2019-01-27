using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using WBase.Unity.Extensions;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Demons { get; private set; } = new List<GameObject>();
    public List<GameObject> Gazebos { get; private set; } = new List<GameObject>();
    public List<GameObject> Houses { get; private set; } = new List<GameObject>();
    public List<GameObject> Portals { get; private set; } = new List<GameObject>();
    public List<GameObject> Gibs { get; private set; } = new List<GameObject>();
    public List<GameObject> Villagers { get; private set; } = new List<GameObject>();

    public int PlayerHappiness = 0;
    public int PlayerGibs = 0;

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

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            foreach(GameObject vil in Villagers)
            {
                vil.GetComponent<Villager>().OnDeath();
            }


        }
    }

    private void PurgeLists()
    {
        Demons.PurgeNulls();
        Gazebos.PurgeNulls();
        Houses.PurgeNulls();
        Portals.PurgeNulls();
        Gibs.PurgeNulls();
    }

    public void UpdateNavMesh()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Navable"))
        {
            NavigationBaker navigationBaker = go.GetComponent<NavigationBaker>();
            if(navigationBaker != null)
            {
                navigationBaker.Bake();
                Debug.Log("Telling " + go.name + " to re-bake navmesh");
            }
        }
    }
}