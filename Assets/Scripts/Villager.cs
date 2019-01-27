using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Log = UnityEngine.Debug;

public class Villager : MonoBehaviour {
    private GameObject GibsPrefab;

    private void Awake()
    {
        GibsPrefab = Resources.Load<GameObject>("Prefabs/Giblets");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDeath()
    {
        GetComponent<VillagerAI>().GameManager.Gibs.Add(Instantiate(GibsPrefab, transform.position, transform.rotation));
        Log.Log("Added Gib to Gib List");
        Destroy(gameObject);
    }
}
