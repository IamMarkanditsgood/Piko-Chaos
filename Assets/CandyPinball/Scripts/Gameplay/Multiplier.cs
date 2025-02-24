using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class Multiplier : MonoBehaviour
    {
        public GameObject m_ScoreParticle;
        bool picked = false;
        Vector3 initPos;
        public int m_Count = 5;
        // Start is called before the first frame update
        void Start()
        {
            initPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (picked)
            {
                transform.localScale -= 10 * Time.deltaTime * Vector3.one;
                if (transform.localScale.x<=0)
                {
                    transform.localScale = Vector3.zero;
                }
            }

            transform.position = initPos + new Vector3(0, 0, 0.3f * Mathf.Sin(3*Time.time));
        }
        void OnTriggerEnter(Collider coll)
        {
            if (!picked)
            {
                if (coll.gameObject.tag == "Player")
                {
                    GameObject obj = Instantiate(m_ScoreParticle);
                    obj.transform.position = transform.position;
                    Destroy(obj, 2);

                    coll.gameObject.GetComponent<Ball>().Multiply(m_Count);

                    picked = true;
                    Destroy(gameObject,2);
                }
            }
        }
    }
}
