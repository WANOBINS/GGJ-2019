using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Log = UnityEngine.Debug;

public class Giblets : MonoBehaviour {
    GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if(!gameManager.Gibs.Contains(gameObject))
            gameManager.Gibs.Add(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Log.Log(gameObject.name + " collided with " + other.name);
        DemonAI Demon = other.gameObject.GetComponent<DemonAI>();
        if (Demon == null)
            return;
        Demon.GibCount++;
        if(gameManager.Gibs.Contains(gameObject))
            gameManager.Gibs.Remove(gameObject);
        Destroy(gameObject);
    }

    void Collect()
    {
        if (gameManager.Gibs.Contains(gameObject))
            gameManager.Gibs.Remove(gameObject);
        gameManager.PlayerGibs++;
        Destroy(gameObject);
    }
}
