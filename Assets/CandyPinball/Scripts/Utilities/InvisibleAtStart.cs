using UnityEngine;
using System.Collections;
namespace JSG.Project_Pinball
{
    public class InvisibleAtStart : MonoBehaviour
    {


        // Use this for initialization
        void Start()
        {
            GetComponent<Renderer>().enabled = false;

        }
    }
}