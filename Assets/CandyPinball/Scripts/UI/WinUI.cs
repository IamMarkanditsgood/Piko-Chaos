using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JSG.Project_Pinball.Gameplay;
using JSG.Project_Pinball.ScriptableObjects;

namespace JSG.Project_Pinball.UI
{
    public class WinUI : MonoBehaviour
    {

        [SerializeField]
        private Button m_Continue;


        [SerializeField]
        private Text m_CoinAmount;
        [SerializeField]
        private Text m_Level;

        [SerializeField]
        private ParticleSystem[] m_Particles;

        [SerializeField, Space]
        private DataStorage m_DataStorage;


        void Start()
        {

        }

        void Update()
        {
            m_Level.text = "Level " + (m_DataStorage.LevelNumber + 1).ToString();

            m_CoinAmount.text = (m_DataStorage.Coin).ToString();
        }



        public void Continue()
        {
            if (m_DataStorage.CheckInternet())
            {
                Invoke("LoadNextScene", 1);
            }
            else
            {
                LoadNextScene();
            }

        }
        private void LoadNextScene()
        {

            m_DataStorage.LevelNumber++;
            if (m_DataStorage.LevelNumber > 30)
            {
                m_DataStorage.LevelNumber = 2;
            }
            m_DataStorage.SaveData();

            SceneManager.LoadScene(m_DataStorage.LevelNumber + 1);
        }
        public void Restart()
        {
            foreach (ParticleSystem p in m_Particles)
            {
                p.Play();
            }
        }

        public void WatchVideo()
        {
            //SoundGallery.PlaySound("Click");
            if (m_DataStorage.CheckInternet())
            {
                //    YodaMainControl.MainYodoControl.m_RewardCoin = 1;
                //    YodaMainControl.MainYodoControl.ShowRewardedVideo();
            }
            else
            {
                //message no internet
                //  UIControl.Current.m_NoNetworkUI.gameObject.SetActive(true);
                Invoke("HideNetworkErrorDelayed", 3);
            }

            //WatchVideoAndGet100MoreCoins
        }

        public void HideNetworkErrorDelayed()
        {
            //   UIControl.Current.m_NoNetworkUI.gameObject.SetActive(false);
        }



    }

}
