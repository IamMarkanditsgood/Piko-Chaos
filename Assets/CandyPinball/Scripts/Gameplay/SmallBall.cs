using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class SmallBall : MonoBehaviour
    {
        public GameObject m_ScoreParticle;
        public Material[] m_Mats;
        public Renderer m_MainRenderer;
        public bool m_Collected = false;

        float moveTime = 0;

        bool IsChecking = true;
        float checkTime = 0;
        Vector3 lastCheckPosition;
        // Start is called before the first frame update
        void Start()
        {
            int r = Random.Range(0, m_Mats.Length);
            m_MainRenderer.material = m_Mats[r];
            GameControl.m_Current.m_SmallBalls.Add(this);
            lastCheckPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (!m_Collected)
            {
                if (transform.position.y< Cup.m_Current.m_FillPoint.position.y)
                {
                    //GameObject obj = Instantiate(m_ScoreParticle);
                    //obj.transform.position = transform.position;
                    //Destroy(obj, 2);

                    //TempSoundControl.m_Current.PlaySound();
                    //GetComponent<Rigidbody>().isKinematic = true;
                    m_Collected = true;
                    GameControl.m_Current.m_CollectedSmallBalls.Add(this);
                    GameControl.m_Current.CollectedCount++;

                    gameObject.layer = 17;
                    GameControl.m_Current.CreateCollectParticle();
                    //Pusher.m_Current.FillTransform.localScale += new Vector3(0, .01f, 0);
                    //Destroy(gameObject,2);
                }
            }
            else
            {
                if (IsChecking)
                {
                    checkTime -= Time.deltaTime;
                    if (checkTime <= 0)
                    {
                        if (Vector3.Distance(transform.position, lastCheckPosition) > 1f)
                        {
                            moveTime = 0;
                        }
                        else
                        {
                            moveTime += Time.deltaTime;
                            if (moveTime > .5f)
                            {
                                //GetComponent<Rigidbody>().isKinematic = true;
                                IsChecking = false;
                                //Invoke("Remove", 1);
                            }
                        }
                        lastCheckPosition = transform.position;
                        checkTime = .2f;
                    }
                }
                //transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, .3f * Time.deltaTime);
                //transform.position = Vector3.Lerp(transform.position, Pusher.m_Current.FillPoint.position, 6 * Time.deltaTime);
            }
        }

        public void Remove()
        {
            GameObject obj = Instantiate(m_ScoreParticle);
            obj.transform.position = transform.position;
            Destroy(obj, 2);

            Destroy(gameObject);
        }

        public void EnableCollision()
        {
            gameObject.layer = 17;
        }

        public void EnableCollisionDelay()
        {
            Invoke("EnableCollision", .5f);
        }
    }
}
