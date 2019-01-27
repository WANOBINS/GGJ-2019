using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Despawn : MonoBehaviour
{
    private float CountStart;
    public float DespawnTime = 10f;
    private void Start()
    {
        CountStart = Time.time;
    }

    private void Update()
    {
        if (Time.time >= DespawnTime + CountStart)
            Destroy(gameObject);
    }
}
