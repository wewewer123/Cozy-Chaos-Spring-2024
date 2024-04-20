using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyChaosSpring2024
{
    public class RugRotation : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            // rotateRugRight();
        }

        public void rotateRugRight(){
            transform.rotation = transform.rotation * Quaternion.Euler(0,0,10);
        }

        public void rotateRugLeft(){
            transform.rotation = transform.rotation * Quaternion.Euler(0,0,-10);
        }
    }
}
