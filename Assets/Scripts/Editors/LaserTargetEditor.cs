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
    [CustomEditor(typeof(LaserTarget))]
    public class LaserTargetEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("LaserHit"))
            {
                ((LaserTarget)target).LaserHit();
            }
        }
    }
}
#endif