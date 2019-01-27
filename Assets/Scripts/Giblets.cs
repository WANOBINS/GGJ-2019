using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Log = UnityEngine.Debug;

public class Giblets : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
        Demon.GameManager.Gibs.Remove(gameObject);
        Destroy(gameObject);
    }
}
