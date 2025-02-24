using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class CameraControl : MonoBehaviour
    {
        private static CameraControl m_Current;
        public static CameraControl Current
        {
            get { return m_Current; }
        }

        private Vector3 m_InitPosition;

        private float m_ShakeTimer;
        private float m_ShakeArc;
        private float m_ShakeRadius = 1;

        private Vector3 m_LerpedPosition;
        private Quaternion m_LerpedRotation;

        [HideInInspector]
        public Camera m_Camera;

        public const int State_Start = 0;
        public const int State_GamePlay = 1;
        public const int State_Win = 2;
      
        public int m_State = 0;


        [SerializeField]
        private Transform[] m_CameraPoints;
        // Start is called before the first frame update

        void Awake()
        {
            m_Current = this;
        }



        void Start()
        {
            transform.position = m_CameraPoints[0].position;
            transform.rotation = m_CameraPoints[0].rotation;
            m_LerpedPosition = transform.position;
            m_LerpedRotation = transform.rotation;

            m_Camera = GetComponent<Camera>();

            m_State = State_Start;
            
        }

        void Update()
        {
            m_ShakeTimer -= Time.deltaTime;
            //ShakeArc += 100 * Time.deltaTime;

            if (m_ShakeTimer <= 0)
                m_ShakeTimer = 0;

            
        }

        // Update is called once per frame
        void LateUpdate()
        {
            Vector3 finalPosition = Vector3.zero;
            Quaternion finalRotation = Quaternion.identity;

            Vector3 ShakeOffset = Vector3.zero;
            float shakeSin = Mathf.Cos(30 * Time.time) * Mathf.Clamp(m_ShakeTimer, 0, 0.5f);
            float shakeCos = Mathf.Sin(50 * Time.time) * Mathf.Clamp(m_ShakeTimer, 0, 0.5f);
            ShakeOffset = new Vector3(m_ShakeRadius * shakeCos, 0, m_ShakeRadius * shakeSin);

            switch (m_State)
            {
                case State_Start:
                    finalPosition = m_CameraPoints[0].position;
                    finalRotation = m_CameraPoints[0].rotation;                           
                    break;

                case State_GamePlay:
                    finalRotation = m_CameraPoints[1].rotation;
                    finalPosition =  m_CameraPoints[1].position;
                    //FinalPosition = transform.position;                
                    break;

                case State_Win:
                    finalRotation = m_CameraPoints[2].rotation;
                    finalPosition =  m_CameraPoints[2].position;
                    //FinalPosition = transform.position;
                    break;
            }

            m_LerpedPosition = Vector3.Lerp(m_LerpedPosition, finalPosition, 5 * Time.deltaTime);
            m_LerpedRotation = Quaternion.Lerp(m_LerpedRotation, finalRotation, 5 * Time.deltaTime);
            transform.position = m_LerpedPosition + ShakeOffset;
            transform.rotation = m_LerpedRotation;

            //Camera cam = GetComponent<Camera>();
            //cam.orthographicSize = 10;
        }

        public void StartShake(float t, float r)
        {
            if (m_ShakeTimer == 0 || m_ShakeRadius < r)
                m_ShakeRadius = r;

            m_ShakeTimer = t;
        }

        public Ray GetRay(Vector3 screenPosition)
        {
            Ray outputRay;
            outputRay = GetComponent<Camera>().ScreenPointToRay(screenPosition);
            return outputRay;
        }

       
    }
}
