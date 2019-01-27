using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTarget : MonoBehaviour {
    GameObject BrokenHouse;

    private void Awake()
    {
        BrokenHouse = Resources.Load<GameObject>("Prefabs/BrokenHouse");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LaserHit()
    {
        GameObject brokenHouse = Instantiate(BrokenHouse, transform.position, transform.rotation);
        Destroy(gameObject);
        brokenHouse.GetComponent<Explosive>().Trigger();
    }
}
