using AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logging = UnityEngine.Debug;

namespace Assets.Scripts.Debug
{
    class NavDebug : MonoBehaviour
    {
        public VillagerAI TestSubject;
        GameObject Enemy;
        private void Awake()
        {

        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit Hit;
                if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out Hit))
                    return;
                TestSubject.NavAgent.SetDestination(Hit.point);
                Logging.Log(TestSubject.gameObject.name + " destination set to " + Hit.point);
            }
            //if (Input.GetMouseButtonDown(1))
            //{
            //    RaycastHit Hit;
            //    if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out Hit))
            //        return;
            //    Instantiate(Enemy, Hit.point, Quaternion.identity);
            //}
        }
    }
}
