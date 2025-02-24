using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSG.Project_Pinball.ScriptableObjects;
namespace JSG.Project_Pinball
{
    public class DataStorageLoader : MonoBehaviour
    {
        [SerializeField]
        private DataStorage m_DataStorage;
        // Start is called before the first frame update
        void Start()
        {
            m_DataStorage.LoadData();

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}