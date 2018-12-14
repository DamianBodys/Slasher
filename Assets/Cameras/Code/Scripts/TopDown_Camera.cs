using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slasher.Cameras
{

    public class TopDown_Camera : MonoBehaviour
    {
        #region Variables
        public Transform m_Target;
        public float m_Height = 10f;
        public float m_Distance = 20f;
        public float m_Angle = 45f;
        public float m_SmoothSpeed = 0.5f;

        private Vector3 refVelocity;
        #endregion



        #region Main Methods
        // Use this for initialization
        void Start()
        {
            HandleCamera();
        }

        // Update is called once per frame
        void Update()
        {
            HandleCamera();
        }
        #endregion

        #region Helper Methods
        protected virtual void HandleCamera()
        {
            if (!m_Target)
            {
                return;
            }

            //Build world position vector
            Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
            Debug.DrawLine(m_Target.position, worldPosition, Color.red);

            //Build our rotated vector
            Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPosition;
            Debug.DrawLine(m_Target.position, rotatedVector, Color.blue);

            //Move camera position
            Vector3 flatTargetPosition = m_Target.position;
            flatTargetPosition.y = 0f;
            Vector3 finalPosition = flatTargetPosition + rotatedVector;
            Debug.DrawLine(m_Target.position, worldPosition, Color.yellow);

            transform.position = Vector3.SmoothDamp(transform.position, finalPosition,ref refVelocity, m_SmoothSpeed);
            transform.LookAt(flatTargetPosition);

        }



        #endregion

    }
}
