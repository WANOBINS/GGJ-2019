using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Floor: MonoBehaviour
    {
        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<House>() != null)
            {
                collision.gameObject.GetComponent<House>().SpawnVillagers();
            }

            if (collision.gameObject.GetComponent<House>() != null || collision.gameObject.GetComponent<Altar>() != null || collision.gameObject.GetComponent<Gazebo>() != null)
            {
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().UpdateNavMesh();
            }
        }
    }
}
