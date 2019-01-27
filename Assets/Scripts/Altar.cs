using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Altar : MonoBehaviour {
    GameManager gameManager;
    DemonAI Demon1;
    DemonAI Demon2;

    public bool LastSleepCheck { get; private set; } = false;
    public GameObject DemonPrefab { get; private set; }

    // Use this for initialization
    void Start () {
        DemonPrefab = Resources.Load<GameObject>("Prefabs/Demon");
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (!gameManager.Portals.Contains(gameObject))
        {
            gameManager.Portals.Add(gameObject);
        }
	}

    // Update is called once per frame
    void Update()
    {

    }

    internal void SpawnDemons()
    {
        if (Demon1 == null)
        {
            Demon1 = Instantiate(DemonPrefab, transform.position, transform.rotation).GetComponent<DemonAI>();
        }
        if (Demon2 == null)
        {
            Demon2 = Instantiate(DemonPrefab, transform.position, transform.rotation).GetComponent<DemonAI,>();
        }
    }

    private void OnDestroy()
    {
        gameManager.UpdateNavMesh();
        if (gameManager.Portals.Contains(gameObject))
        {
            gameManager.Portals.Remove(gameObject);
        }
    }
}
