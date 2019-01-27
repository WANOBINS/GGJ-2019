using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazebo : MonoBehaviour {
    GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (!gameManager.Gazebos.Contains(gameObject))
        {
            gameManager.Gazebos.Add(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDestroy()
    {
        if (gameManager.Gazebos.Contains(gameObject))
        {
            gameManager.Gazebos.Remove(gameObject);
        }
    }
}
