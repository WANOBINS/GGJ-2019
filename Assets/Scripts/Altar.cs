using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Altar : MonoBehaviour {
    GameManager gameManager;

    public bool LastSleepCheck { get; private set; } = false;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (!gameManager.Portals.Contains(gameObject))
        {
            gameManager.Portals.Add(gameObject);
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().IsSleeping())
        {
            if (!LastSleepCheck)
                gameManager.UpdateNavMesh();
            LastSleepCheck = GetComponent<Rigidbody>().IsSleeping();
        }
    }

    private void OnDestroy()
    {
        if (gameManager.Portals.Contains(gameObject))
        {
            gameManager.Portals.Remove(gameObject);
        }
    }
}
