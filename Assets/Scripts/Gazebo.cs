using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WBase.Unity.Extensions;

public class Gazebo : MonoBehaviour {
    GameManager gameManager;

    public bool LastSleepCheck { get; private set; } = false;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (!gameManager.Gazebos.Contains(gameObject))
        {
            gameManager.Gazebos.Add(gameObject);
        }
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        gameManager.UpdateNavMesh();
        if (gameManager.Gazebos.Contains(gameObject))
        {
            gameManager.Gazebos.Remove(gameObject);
        }
    }

    public void SetStatic(bool isStatic)
    {
        foreach(GameObject go in gameObject.GetChildrenRecursively())
        {
            go.isStatic = isStatic;
        }
    }
}

