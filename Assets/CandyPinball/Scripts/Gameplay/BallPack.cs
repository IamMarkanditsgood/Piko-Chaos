using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class BallPack : MonoBehaviour
    {
        public int m_BallCount = 10;
        public GameObject m_SmallBallPrefab;
        // Start is called before the first frame update
        void Start()
        {

            Vector3[] positions = ArrangePositions(m_BallCount);

            for (int i = 0; i < m_BallCount; i++)
            {
                GameObject obj = Instantiate(m_SmallBallPrefab);
                obj.transform.position =transform.position+ positions[i];

                float deltaAngle = 360f / m_BallCount;
                //Rigidbody body = obj.GetComponent<Rigidbody>();
                //body.velocity = Quaternion.Euler(0, 0, i * deltaAngle) * (Random.Range(5f, 9f) * Vector3.right);
            }

        }


        public Vector3[] ArrangePositions(int count)
        {
            int RawCount = 10;
            Vector3[] positions = new Vector3[count];
            int x = 0;
            int y = 0;
            float distance = .9f;
            float yDistance = .9f;

            for (int i = 0; i < count; i++)
            {

                float start = -(RawCount / 2f) * distance + (0.5f * distance);
                //print(start);
                positions[i] = new Vector3(start + (x) * distance, y * yDistance, 0);
                x++;
                if (x >= RawCount)
                {
                    x = 0;
                    y++;
                }
            }

            return positions;
        }
        // Update is called once per frame
        void Update()
        {

        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.white;

            Vector3[] positions = ArrangePositions(m_BallCount);


            for (int i = 0; i < m_BallCount; i++)
            {
                Gizmos.DrawWireSphere(transform.position + positions[i], .4f);
            }
            
        }
    }
}
