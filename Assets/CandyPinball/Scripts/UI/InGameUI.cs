using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JSG.Project_Pinball.Gameplay;
using JSG.Project_Pinball.ScriptableObjects;

namespace JSG.Project_Pinball.UI
{
    public class InGameUI : MonoBehaviour
    {

        [SerializeField]
        private Button m_Back;
        [SerializeField]
        private Button m_Skip;


        [SerializeField]
        private Text m_CoinAmount;


        [SerializeField]
        private GameObject m_ShootHint;

        [SerializeField, Space]
        private DataStorage m_DataStorage;

        // Start is called before the first frame update
        void Start()
        {
            //AdmobControl.m_Current.RequestInterstitialBanner();
            m_Back.onClick.AddListener(BtnBack);

            m_ShootHint.SetActive(false);

        }

        private void Update()
        {



        }

        public void ShowShootHint()
        {
            m_ShootHint.SetActive(true);
        }

        public void HideShootHint()
        {
            m_ShootHint.SetActive(false);
        }

        public void BtnBack()
        {
            //SoundGallery.PlaySound("Click");
            //TapsellPlusControl.MainTapsellPlusControl.RequestIntersetialBannerAd();
            //YodaMainControl.MainYodoControl.ShowIntersetial();
            //UIControl.Current.TransitionOut();
            Application.Quit();
            //GameControl.Current.RestartLevel();
        }

        //public void BtnSkip()
        //{
        //    SoundGallery.PlaySound("Click");

        //    if (m_DataStorage.CheckInternet())
        //    {
        //        TapsellPlusControl.MainTapsellPlusControl.Request_Video_SkipLevel();
        //    }
        //    else
        //    {
        //        UIControl.Current.m_NoNetworkUI.gameObject.SetActive(true);
        //        Invoke("HideNetworkErrorDelayed", 3);
        //    }

        //}

        public void HideNetworkErrorDelayed()
        {
            // UIControl.Current.m_NoNetworkUI.gameObject.SetActive(false);
        }

        public void BtnRestart()
        {
            if (m_DataStorage.CheckInternet())
            {
                Invoke("LoadRestart", 2);
            }
            else
            {
                LoadRestart();
            }

        }
        private void LoadRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}