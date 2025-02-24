using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSG.Project_Pinball.ScriptableObjects
{
    [CreateAssetMenu(fileName = "DataStorage", menuName = "CustomObjects/DataStorage", order = 1)]
    public class DataStorage : ScriptableObject
    {
        public int Coin;
        public int LevelCoin;
        public int LevelNumber;
        public int UnlockedLevelNumber;

        [HideInInspector]
        public int m_UnlockCounter = 0;
        [HideInInspector]
        public int m_NewUnlock = -1;
        [HideInInspector]
        public int[] m_UnlockLevels;
        public int m_TotalLevelCount = 36;

        public void SaveData()
        {
            PlayerPrefs.SetInt("Coin", Coin);
            PlayerPrefs.SetInt("LevelNumber", LevelNumber);
            PlayerPrefs.SetInt("UnlockedLevelNumber", UnlockedLevelNumber);
            PlayerPrefs.SetInt("m_UnlockCounter", m_UnlockCounter);
            PlayerPrefs.SetInt("m_NewUnlock", m_NewUnlock);
            PlayerPrefs.Save();
        }

        public void LoadData()
        {
            Coin = PlayerPrefs.GetInt("Coin", 0);

            LevelNumber = PlayerPrefs.GetInt("LevelNumber", 0);
            UnlockedLevelNumber = PlayerPrefs.GetInt("UnlockedLevelNumber", 0);
            if (UnlockedLevelNumber < LevelNumber)
            {
                UnlockedLevelNumber = LevelNumber;
            }
            m_UnlockCounter = PlayerPrefs.GetInt("m_UnlockCounter", 0);
            m_NewUnlock = PlayerPrefs.GetInt("m_NewUnlock", 0);
        }

        public void ResetDate()
        {
            LevelNumber = 0;
            Coin = 0;
            SaveData();
        }

        public bool CheckInternet()
        {
            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
                return true;
            return false;
        }
    }
}
