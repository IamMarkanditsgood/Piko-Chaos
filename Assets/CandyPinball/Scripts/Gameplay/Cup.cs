using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class Cup : MonoBehaviour
    {
        public static Cup m_Current;
        public Transform m_FillPoint;

        public Transform FillBar;

        public Vector3 InitPosition;
        void Awake()
        {
            m_Current = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            InitPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            float y = (GameControl.m_Current.NeededBalls / 250f) * 5f;
            FillBar.localPosition = new Vector3(0, y, 0);

            //            transform.position = InitPosition + TempSoundControl.m_Current.ShakeTime* new Vector3(0.1f * Mathf.Cos(30*Time.time), 0, 0);
            //            transform.rotation = Quaternion.Euler(0, 0, TempSoundControl.m_Current.ShakeTime * 4 * Mathf.Cos(50 * Time.time));
        }
    }
}
