using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball.Gameplay
{
    public class BounceStick : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision c)
        {
            if (c.gameObject.tag == "Player")
            {
                Vector3 dir = c.gameObject.transform.position - transform.position;
                dir.z = 0;
                dir.Normalize();
                c.gameObject.GetComponent<Rigidbody>().velocity = 50 * dir;

            }
        }
    }
}
