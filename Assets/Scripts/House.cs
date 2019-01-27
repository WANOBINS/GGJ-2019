using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {
    GameManager gameManager;
    GameObject VillagerPrefab;
    Villager Villager1 = null;
    Villager Villager2 = null;
    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        VillagerPrefab = Resources.Load<GameObject>("Prefab/Villager");
        if (!gameManager.Houses.Contains(gameObject))
        {
            gameManager.Houses.Add(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Villager1 == null)
        {
            Villager1 = Instantiate(VillagerPrefab, transform.position,transform.rotation).GetComponent<Villager>();
        }
        if (Villager2 == null)
        {
            Villager2 = Instantiate(VillagerPrefab, transform.position, transform.rotation).GetComponent<Villager>();
        }
    }

    private void OnDestroy()
    {
        if (gameManager.Houses.Contains(gameObject))
        {
            gameManager.Houses.Remove(gameObject);
        }
    }
}
