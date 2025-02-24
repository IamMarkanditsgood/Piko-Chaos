using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class TouchControl : MonoBehaviour
    {
        private Vector3 v_InitPosition = Vector3.zero;
        public Vector3 InitPosition
        {
            get { return v_InitPosition; }
        }
        private Vector3 v_CurrentPosition = Vector3.zero;
        public Vector3 CurrentPosition
        {
            get { return v_CurrentPosition; }
        }

        private Vector3 m_InputDirection;
        public Vector3 InputDirection
        {
            get { return m_InputDirection; }
        }

        public Vector3 m_CurrentPositionUnit = Vector3.zero;
        public Vector3 m_InitPositionUnit = Vector3.zero;


        private bool m_Touched = false;

        private bool m_IsTouching = false;
        public bool IsTouching
        {
            get { return m_IsTouching; }
        }

        private static TouchControl m_Current;
        public static TouchControl CurrentTouchControl
        {
            get { return m_Current; }
        }

        void Awake()
        {
            m_Current = this;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            m_IsTouching = false;

            if (Input.GetMouseButton(0))
            {
                m_IsTouching = true;
                v_CurrentPosition = Input.mousePosition;
                m_CurrentPositionUnit = Vector3.zero;
                m_CurrentPositionUnit.x = v_CurrentPosition.x / Screen.width;
                m_CurrentPositionUnit.y = v_CurrentPosition.y / Screen.height;
            }

            if (Input.touchCount==1)
            {
                m_IsTouching = true;
                v_CurrentPosition = Input.touches[0].position;
                m_CurrentPositionUnit = Vector3.zero;
                m_CurrentPositionUnit.x = v_CurrentPosition.x / Screen.width;
                m_CurrentPositionUnit.y = v_CurrentPosition.y / Screen.height;
            }

            if (IsTouching)
            {
                
                if (!m_Touched)
                {
                    v_InitPosition = v_CurrentPosition;
                    m_InitPositionUnit = m_CurrentPositionUnit;
                    m_Touched = true;
                }
                m_InputDirection = v_CurrentPosition - v_InitPosition;
                float maxDistance = 0.05f * Screen.width;
                m_InputDirection = m_InputDirection / maxDistance;
                m_InputDirection = Vector3.ClampMagnitude(m_InputDirection, 1);

                //v_InitPosition = Vector3.Lerp(v_InitPosition, v_CurrentPosition, .5f*Time.deltaTime);
            }
            else
            {
                m_InputDirection = Vector3.zero;
                   m_Touched = false;
            }
        }
    }
}
