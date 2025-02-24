using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class Ball : MonoBehaviour
    {
        public static Ball m_Current;
        public GameObject m_SmallBallPrefab;
        public GameObject m_WallSmashParticle;

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

        }

        public void Multiply(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject obj = Instantiate(m_SmallBallPrefab);
                obj.transform.position = transform.position;
                obj.layer = 16;
                obj.GetComponent<SmallBall>().EnableCollisionDelay();
                float deltaAngle = 360f / count;
                Rigidbody body = obj.GetComponent<Rigidbody>();
                body.velocity = Quaternion.Euler(0, 0, i * deltaAngle) *(Random.Range(5f,9f)* Vector3.right);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Block")
            {
                GameObject obj = Instantiate(m_WallSmashParticle);
                obj.transform.position = collision.gameObject.transform.position;
                Destroy(obj,3);
                Destroy(collision.gameObject);

            }
            else if (collision.gameObject.tag == "Shooter")
            {
                //GameObject obj = Instantiate(m_WallSmashParticle);
                //obj.transform.position = collision.gameObject.transform.position;
                //Destroy(obj, 3);

                GetComponent<Rigidbody>().velocity = 50*( collision.gameObject.transform.rotation* Vector3.up);
                GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 0, 200);

            }

        }
    }
}
