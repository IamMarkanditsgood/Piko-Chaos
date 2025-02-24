using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class Shooter : MonoBehaviour
    {
        public GameObject m_ScoreParticle;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player")
            {
                GameObject obj = Instantiate(m_ScoreParticle);
                obj.transform.position = transform.position;
                Destroy(obj, 2);

                Ball.m_Current.transform.position = transform.position;
                Ball.m_Current.GetComponent<Rigidbody>().velocity = 30 * (transform.rotation * Vector3.up);
                Ball.m_Current.GetComponent<Rigidbody>().angularVelocity = new Vector3(100, 0, 200);
            }

        }
    }
}
