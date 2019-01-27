﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    LineRenderer laserRenderer;
    public GameObject[] Buildings;
    public int SelectedBuild = 0;
	// Use this for initialization
	void Start ()
    {
        laserRenderer = GetComponent<LineRenderer>();        
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
                
                if(Input.GetMouseButtonUp(0)|| Input.GetKeyUp(KeyCode.LeftAlt))
                laserRenderer.enabled = false;
                print(LaserHit.point);
            }
        }
        else if(Input.GetMouseButtonDown(0)) // Spawn Buildings
        {
            if (Physics.Raycast(ray, out LaserHit))
            {
                Instantiate(Buildings[SelectedBuild], LaserHit.point + new Vector3(0f, 50f, 0f), transform.rotation);
                                    
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
