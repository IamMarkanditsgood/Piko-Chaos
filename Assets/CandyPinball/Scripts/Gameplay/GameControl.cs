using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSG.Project_Pinball.UI;
using JSG.Project_Pinball.ScriptableObjects;

namespace JSG.Project_Pinball.Gameplay
{
    public class GameControl : MonoBehaviour
    {
        public static GameControl m_Current;


        [SerializeField, Space]
        private DataStorage m_DataStorage;
        [HideInInspector]
        public int m_State = 0;

        public const int State_Start = 0;
        public const int State_Gameplay = 1;
        public const int State_Lose = 2;
        public const int State_Shoot = 3;
        public const int State_End = 4;
        public const int State_Win = 5;
        [HideInInspector]
        public float State_Timer = 0;


        [HideInInspector]
        public List<SmallBall> m_SmallBalls;
        [HideInInspector]
        public List<SmallBall> m_CollectedSmallBalls;
        public int NeededBalls;
        public int CollectedCount = 0;
        [HideInInspector]
        public bool Won = false;

        public GameObject m_MainBall;
        public GameObject m_Structure;
        public GameObject m_Level;

        public GameObject m_CollectParticle;

        void Awake()
        {
            m_Current = this;
        }
        // Start is called before the first frame update
        void Start()
        {

            m_State = State_Start;
            Invoke("StartGameplay", 1);
            m_SmallBalls = new List<SmallBall>();
            m_CollectedSmallBalls = new List<SmallBall>();
            CollectedCount = 0;
        }

        // Update is called once per frame
        void Update()
        {


            //if ( <= 0)
            //{
            //    m_EnemyGroupCounter++;
            //    SpawnEnemyPawns();
            //}

            switch (m_State)
            {
                case State_Start:
                    CameraControl.Current.m_State = CameraControl.State_Start;
                    break;

                case State_Gameplay:
                    CameraControl.Current.m_State = CameraControl.State_GamePlay;
                    if (CollectedCount >= NeededBalls)
                    {
                        HandleWin();
                    }

                    //


                    break;
                case State_Win:
                    CameraControl.Current.m_State = CameraControl.State_Win;
                    break;

            }

        }


        public void HandleGameOver()
        {
            //GameAnalyticsControl.m_Current.LogLevelFailEvent(10);
            //show ui
            m_State = State_Lose;
            State_Timer = 0;
            UIControl.Current.m_InGameUI.SetActive(false);
            UIControl.Current.m_LoseUI.SetActive(true);

        }

        public void HandleWin()
        {
            //SoundGallery.PlaySound("win2");

            //GameAnalyticsControl.m_Current.LogLevelCompleteEvent(10);
            CameraControl.Current.m_State = CameraControl.State_Win;

            //show ui
            m_State = State_End;
            State_Timer = 0;
            UIControl.Current.m_InGameUI.SetActive(false);
            UIControl.Current.m_WinUI.SetActive(true);

            Pusher.m_Current.gameObject.SetActive(false);
            m_MainBall.SetActive(false);
            //m_Structure.SetActive(false);
            //m_Level.SetActive(false);
        }





        public void ResetPoints()
        {

        }


        public void StartGameplay()
        {
            m_State = State_Gameplay;
            State_Timer = 0;
        }

        public void CreateCollectParticle()
        {
            GameObject obj = Instantiate(m_CollectParticle);
            obj.transform.position = Cup.m_Current.m_FillPoint.position;
            Destroy(obj, 2);
        }
    }
}