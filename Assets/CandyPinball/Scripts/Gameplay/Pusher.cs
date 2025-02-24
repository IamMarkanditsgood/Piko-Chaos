using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class Pusher : MonoBehaviour
    {
        public GameObject m_Ball;
        bool haveBall = true;
        public Transform ArrowBase;
        
        public Transform BallPoint;

        public static Pusher m_Current;

        public GameObject m_ShootParticlePrefab;
        public ParticleSystem[] m_Particles;

        void Awake()
        {
            m_Current = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            m_Particles[0].Stop();
            m_Particles[1].Stop();
        }

        // Update is called once per frame
        void Update()
        {
            

            if (haveBall)
            {
                m_Ball.GetComponent<Rigidbody>().isKinematic = true;
                m_Ball.transform.position = BallPoint.position;
                ArrowBase.localRotation = Quaternion.Euler(0, 0, 55*Mathf.Sin(Time.time));
               
            }
            else
            {
                
                if (m_Ball.transform.position.y< transform.position.y)
                {
                    m_Particles[0].Play();
                    m_Particles[1].Play();
                    haveBall = true;
                }
            }

            bool hit = false;

                if (Input.GetMouseButtonDown(0))
                {
                    hit = true;
                }
                if (Input.touchCount > 0)
                {
                    hit = true;
                }
            

            if (hit)
            {
                if (GameControl.m_Current.m_State == GameControl.State_Gameplay)
                {
                    if (haveBall)
                    {
                        m_Ball.GetComponent<Rigidbody>().isKinematic = false;
                        m_Ball.GetComponent<Rigidbody>().velocity = 50 * (ArrowBase.rotation * Vector3.up);
                        m_Ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 0, 200);
                        haveBall = false;

                        GameObject obj = Instantiate(m_ShootParticlePrefab);
                        obj.transform.position =BallPoint.position;
                        obj.transform.forward = ArrowBase.rotation * Vector3.up;
                        Destroy(obj, 4);

                        m_Particles[0].Stop();
                        m_Particles[1].Stop();

                        CameraControl.Current.StartShake(.4f, .2f);
                    }
                }

                //Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
                //foreach (Collider c in colliders)
                //{
                //    if (c.gameObject.GetComponent<Rigidbody>() != null)
                //    {
                //        Vector3 dir = c.gameObject.transform.position - transform.position;
                //        dir.z = 0;
                //        if (dir.magnitude <= 3)
                //        {
                //            dir.Normalize();
                //            c.gameObject.GetComponent<Rigidbody>().velocity = 50 * dir;
                //        }
                //        //break;
                //    }
                //}
            }

            //if (!Won)
            //{
                //if (CollectedCount > 150)
                //{
                //    Won = true;
                //    foreach(SmallBall ball in m_SmallBalls)
                //    {
                //        //ball.GetComponent<Rigidbody>().isKinematic = true;
                //        if (!ball.m_Collected && ball.transform.position.y > transform.position.y)
                //        {
                //            ball.Remove();
                //        }
                //    }
                //}
            //}

            //print("Collected : " + m_CollectedSmallBalls.Count.ToString());
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, 3);
        }
    }
}
