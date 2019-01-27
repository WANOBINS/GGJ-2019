using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {
    GameManager gameManager;
    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (!gameManager.Houses.Contains(gameObject))
        {
            gameManager.Houses.Add(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        if (gameManager.Houses.Contains(gameObject))
        {
            gameManager.Houses.Remove(gameObject);
        }
    }
}
