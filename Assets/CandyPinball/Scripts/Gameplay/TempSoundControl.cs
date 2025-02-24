using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class TempSoundControl : MonoBehaviour
    {
        bool DelayPlay = false;
        public AudioSource m_AudioSource;
        public AudioClip m_Sound;

        public static TempSoundControl m_Current;
        [HideInInspector]
        public float ShakeTime = 0;

        void Awake()
        {
            m_Current = this;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ShakeTime -= 3*Time.deltaTime;
            if (ShakeTime <= 0)
                ShakeTime = 0;


        }

        public void Shake()
        {
            ShakeTime = 1;
        }

        public void PlaySound()
        {
            if (!DelayPlay)
            {
                ShakeTime = 1;
                m_AudioSource.pitch += 0.02f;
                m_AudioSource.PlayOneShot(m_Sound);
                DelayPlay = true;
                Invoke("EndDelay", .1f);
            }
        }

        public void EndDelay()
        {
            DelayPlay = false;
        }
    }
}
