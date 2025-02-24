using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JSG.ConnectDots.Gameplay
{
    public class Coin : MonoBehaviour
    {
        Vector3 InitPosition;
        Vector3 FinalPosition;
        float lerp = 0;

        [SerializeField]
        private AnimationCurve m_MoveCurve;
        // Start is called before the first frame update
        void Start()
        {
            InitPosition = transform.position;
            FinalPosition = InitPosition + new Vector3(Random.Range(-9, 9), 0, Random.Range(-5, -25));
            lerp = 0;

            Destroy(gameObject, Random.Range(2f, 3f));
        }

        // Update is called once per frame
        void Update()
        {
            lerp += Time.deltaTime;
            transform.position = Vector3.Lerp(InitPosition, FinalPosition, lerp) + new Vector3(0, 6 * m_MoveCurve.Evaluate(lerp), 0);
        }
    }
}
