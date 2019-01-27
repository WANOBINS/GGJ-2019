#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editors
{
    [CustomEditor(typeof(Explosive))]
    class ExplosiveEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Detonate"))
            {
                ((Explosive)target).Trigger();
            }
        }
    }
}
#endif
