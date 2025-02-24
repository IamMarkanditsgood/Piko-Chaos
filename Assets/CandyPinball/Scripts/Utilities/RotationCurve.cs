using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.Project_Pinball
{
    public class RotationCurve : MonoBehaviour
    {
        public AnimationCurve m_Curve;
        public Vector3 Axis;
        float timer = 0;
        public float Speed = 1;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timer += Speed * Time.deltaTime;
            if (timer > 1)
            {
                timer = timer - 1;
            }
            transform.localRotation = Quaternion.AngleAxis(m_Curve.Evaluate(timer), Axis);
        }
    }
}