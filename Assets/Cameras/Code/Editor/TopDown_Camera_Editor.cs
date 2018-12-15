using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Slasher.Cameras
{
    [CustomEditor(typeof(TopDown_Camera))]
    public class TopDown_Camera_Editor : Editor
    {

        #region Variables
        private TopDown_Camera targetCamera;
        #endregion

        #region Main Methods

        void OnEnable()
        {
            targetCamera = (TopDown_Camera)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        private void OnSceneGUI()
        {
            if(!targetCamera.m_Target)
            {
                return;
            }

            Handles.color = new Color(1f, 0f, 0f, 0.15f);
            Handles.DrawSolidDisc(targetCamera.m_Target.position, Vector3.up, targetCamera.m_Distance);

            Handles.color = new Color(1f, 1f, 0f, 0.75f);
            Handles.DrawWireDisc(targetCamera.m_Target.position, Vector3.up, targetCamera.m_Distance);

            Handles.color = new Color(1f, 0f, 0f, 0.5f);
            targetCamera.m_Distance = Handles.ScaleSlider(targetCamera.m_Distance, targetCamera.m_Target.position, -targetCamera.m_Target.forward, Quaternion.identity, targetCamera.m_Distance, 1f);
            targetCamera.m_Distance = Mathf.Clamp(targetCamera.m_Distance, 1f, float.MaxValue);

            Handles.color = new Color(0f, 0f, 1f, 0.5f);
            targetCamera.m_Height = Handles.ScaleSlider(targetCamera.m_Height, targetCamera.m_Target.position, Vector3.up, Quaternion.identity, targetCamera.m_Height, 1f);
            targetCamera.m_Height = Mathf.Clamp(targetCamera.m_Height, 1f, float.MaxValue);
        }

        #endregion
    }
}
