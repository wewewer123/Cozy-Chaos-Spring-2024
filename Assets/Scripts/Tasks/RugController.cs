using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CozyChaosSpring2024
{
    public class RugController : MonoBehaviour
    {
        public GameObject smallRug;
        public GameObject largeRug;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Quaternion smallRotation = smallRug.GetComponent<Transform>().rotation;
            Quaternion largeRotation = largeRug.GetComponent<Transform>().rotation;
            if (smallRotation == Quaternion.Euler(-90, 0,0) && largeRotation == Quaternion.Euler(-90, 0,0)){
                // print("small rug done");
                SceneManager.LoadScene(0);
            }
        }
    }
}
