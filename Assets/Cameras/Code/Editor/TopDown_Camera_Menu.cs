using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Slasher.Cameras
{
    public class TopDown_Camera_Menu : MonoBehaviour
    {
        [MenuItem("Slasher/Cameras/Top Down Camera")]
        public static void CreateTopDownCamera()
        {
            GameObject[] selectedGOs = Selection.gameObjects;

            if(selectedGOs.Length > 0 && selectedGOs[0].GetComponent<Camera>())
            {
                if(selectedGOs.Length < 2)
                {
                    AttachTopDownScript(selectedGOs[0].gameObject, null);
                }

                else if(selectedGOs.Length == 2)
                {
                    AttachTopDownScript(selectedGOs[0].gameObject, selectedGOs[1].transform);
                }

                else if(selectedGOs.Length > 2)
                {
                    EditorUtility.DisplayDialog("Camera Tools", "You need to select one or two game objects for this to work," +
                        " and the first needs to be a camera!", "OK");
                }

            }
            else
            {
                EditorUtility.DisplayDialog("Camera Tools", "You need to selec a game object that has the Camera component " +
                    "for this to work!", "OK");
            }
        }


        static void AttachTopDownScript(GameObject camera, Transform target)
        {
            TopDown_Camera cameraScript = null;
            if (camera)
            {
                cameraScript = camera.AddComponent<TopDown_Camera>();
            }

            if(cameraScript && target)
            {
                cameraScript.m_Target = target;
            }

        }
    }
}
