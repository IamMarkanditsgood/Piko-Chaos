using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSG.Project_Pinball.Gameplay;

namespace JSG.Project_Pinball.UI
{
    public class UIControl : MonoBehaviour
    {
        private static UIControl m_Current;
        public static UIControl Current
        { get { return m_Current; } }

        public GameObject m_InGameUI;
        public GameObject m_LoseUI;
        public GameObject m_WinUI;
       

        [Space]
       [SerializeField]
        private Camera m_EventCamera;
        [SerializeField]
        public Animator m_TransitionAnimator;

        void Awake()
        { m_Current = this; }

        void Start()
        {
            Canvas[] allCanvas= GetComponentsInChildren<Canvas>(true);
            //print(allCanvas.Length);
            foreach(Canvas c in allCanvas)
            {
                c.worldCamera = m_EventCamera;
            }

            //m_TransitionAnimator.gameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}
