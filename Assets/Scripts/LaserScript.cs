using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WBase.Unity;

public class LaserScript : MonoBehaviour
{
    LineRenderer laserRenderer;
    public GameObject[] Buildings;
    public int SelectedBuild = 0;
    public GameManager myGM;
    public CoolDown BuildCooldown = new CoolDown(5);
	// Use this for initialization
	void Start ()
    {
        laserRenderer = GetComponent<LineRenderer>();
        myGM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit LaserHit;

        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(0))
        {            
            if(Physics.Raycast(ray,out LaserHit))
            {
                laserRenderer.enabled = true;
                laserRenderer.SetPosition(0, transform.position);
                laserRenderer.SetPosition(1, LaserHit.point);


                House houseHit = LaserHit.collider.transform.GetComponentInParent<House>();
                if(houseHit != null)
                {
                    houseHit.gameObject.AddComponent<LaserTarget>().LaserHit();
                }

                print(LaserHit.point);
            }
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.LeftAlt))
        {
            laserRenderer.enabled = false;
        }
        else if(Input.GetMouseButtonDown(0)) // Spawn Buildings
        {
            if (Physics.Raycast(ray, out LaserHit))
            {
                if (BuildCooldown.Start())
                {
                    if (Buildings[SelectedBuild].GetComponent<Altar>() == null)
                    {
                        GameObject NewBuild = Instantiate(Buildings[SelectedBuild], LaserHit.point + new Vector3(0f, 50f, 0f), Quaternion.Euler(0,-transform.rotation.eulerAngles.y,0));
                       
                    }
                    else
                    {
                        //if (myGM.PlayerGibs >= 5)
                       // {
                            GameObject NewBuild = Instantiate(Buildings[SelectedBuild], LaserHit.point + new Vector3(0f, 50f, 0f), Quaternion.Euler(0, -transform.rotation.eulerAngles.y, 0));                           
                         //   myGM.PlayerGibs -= 5;
                        //}
                    }
                }
                                    
                print(LaserHit.point);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedBuild = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedBuild = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedBuild = 2;
        }
    }   
}
