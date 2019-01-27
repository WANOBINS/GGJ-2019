#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Editors
{
    [CustomEditor(typeof(GameManager))]
    class GameManagerEditor:Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Re-Bake"))
            {
                ((GameManager)target).UpdateNavMesh();
            }
        }
    }
}
#endif
