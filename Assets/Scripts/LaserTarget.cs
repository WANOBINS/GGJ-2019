using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTarget : MonoBehaviour {
    GameObject BrokenHouse;
    GameObject Gibs;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        BrokenHouse = Resources.Load<GameObject>("Prefabs/BrokenHouse");
        Gibs = Resources.Load<GameObject>("Prefabs/Giblets");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LaserHit()
    {
        if (gameObject.GetComponent<House>() != null)
        {
            GameObject brokenHouse = Instantiate(BrokenHouse, transform.position, transform.rotation);
            Destroy(gameObject);
            brokenHouse.GetComponent<Explosive>().Trigger();
        }
        gameManager.UpdateNavMesh();
    }
}
