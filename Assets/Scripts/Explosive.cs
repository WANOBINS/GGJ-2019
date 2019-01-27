using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using WBase.Unity.Extensions;

public class Explosive : MonoBehaviour {
    public float ExplosiveForce = 10f;
    public float ExplosionRadius = 5f;
    Transform[] transforms;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger()
    {
        transforms = gameObject.transform.GetChildrenRecursive();
        gameObject.AddComponent<Despawn>();
        foreach(Transform t in transforms)
        {
            if (t == null)
                continue;
            t.gameObject.AddComponent<Despawn>();
            
            t.parent = null;
            MeshFilter meshFilter = t.GetComponent<MeshFilter>();
            if (meshFilter == null)
                continue;
            Rigidbody rb = t.gameObject.AddComponent<Rigidbody>();
            rb.useGravity = true;
            MeshCollider mc = t.gameObject.AddComponent<MeshCollider>();
            mc.sharedMesh = meshFilter.mesh;
            mc.convex = true;
            foreach(GameObject other in GameObject.FindGameObjectsWithTag("Villager"))
            {
                Collider oc = other.GetComponent<Collider>();
                if(oc != null && mc != null)
                {
                    Physics.IgnoreCollision(oc, mc);
                }
            }
           // t.gameObject.AddComponent<NavMeshObstacle>().size = new Vector3().FromFloat(1.1f);
            rb.AddExplosionForce(ExplosiveForce, transform.position, ExplosionRadius);
        }
    }

    private void OnDestroy()
    {
        foreach(Transform t in transforms)
        {
            Destroy(t);
        }
    }
}
