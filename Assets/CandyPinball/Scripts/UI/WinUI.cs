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
            m_Continue.onClick.AddListener(LoadNextScene);
        }


        private void OnEnable()
        {
            int _currentLevel = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.CurrentLevel);
            m_Level.text = "Level " + (_currentLevel + 1) + " completed";
            SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.CurrentLevel, (_currentLevel + 1));
            TextManager textManager = new TextManager();
            textManager.SetText(m_DataStorage.Coin, m_CoinAmount, true, "+");
            ResourcesManager.Instance.ModifyResource(ResourceTypes.Coins, m_DataStorage.Coin);
        }

        private void OnDestroy()
        {
            m_Continue.onClick.RemoveAllListeners();    
        }


        public void Continue()
        {/*
            if (m_DataStorage.CheckInternet())
            {
                Invoke("LoadNextScene", 1);
            }
            else
            {
                LoadNextScene();
            }*/

        }
        private void LoadNextScene()
        {
            if (SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.CurrentLevel) < 10)
            {
                m_DataStorage.LevelNumber++;
                if (m_DataStorage.LevelNumber > 30)
                {
                    m_DataStorage.LevelNumber = 2;
                }
                m_DataStorage.SaveData();

                SceneManager.LoadScene(m_DataStorage.LevelNumber + 1);
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
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
