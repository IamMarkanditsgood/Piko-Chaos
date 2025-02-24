using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JSG.Project_Pinball.ScriptableObjects;
using UnityEngine.SceneManagement;

namespace JSG.Project_Pinball.UI
{
    public class LoseUI : MonoBehaviour
    {

        [SerializeField]
        private Button m_Retry;
        [SerializeField]
        private Button m_Skip;

        [SerializeField]
        private Text m_CoinAmount;
        [SerializeField]
        private Text m_Level;

        [SerializeField]
        private Image m_Player;

        [SerializeField]
        private DataStorage m_DataStorage;

        void Start()
        {
            m_CoinAmount.text = m_DataStorage.Coin.ToString();
        }

        void Update()
        {

                m_Level.text = "Level " + (m_DataStorage.LevelNumber + 1).ToString();
            

            m_CoinAmount.text = (m_DataStorage.Coin).ToString();
        }


        public void Yes()
        {
            //SoundGallery.PlaySound("Click");

            // TapsellPlusControl.MainTapsellPlusControl.RequestIntersetialBannerAd();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //UIControl.Current.TransitionOut();
            //GameControl.Current.RestartLevel();
            //SceneManager. LoadScene(scene.name);

        }
        public void No()
        {
            //SoundGallery.PlaySound("Click");
            //TapsellPlusControl.MainTapsellPlusControl.RequestIntersetialBannerAd();
            //YodaMainControl.MainYodoControl.ShowIntersetial();
           // UIControl.Current.TransitionOut();
            Application.Quit();
            //GameControl.Current.RestartLevel();


        }

        //public void Skip()
        //{
        //    SoundGallery.PlaySound("Click");
        //    if (m_DataStorage.CheckInternet())
        //    {
        //        TapsellPlusControl.MainTapsellPlusControl.Request_Video_SkipLevel();

        //    }
        //    else
        //    {
        //        //message no internet
        //        UIControl.Current.m_NoNetworkUI.gameObject.SetActive(true);
        //        Invoke("HideNetworkErrorDelayed", 3);
        //    }
        //    //WatchVideoAndSkipLevel

        //}

        public void HideNetworkErrorDelayed()
        {
         //   UIControl.Current.m_NoNetworkUI.gameObject.SetActive(false);
        }
    }
}
