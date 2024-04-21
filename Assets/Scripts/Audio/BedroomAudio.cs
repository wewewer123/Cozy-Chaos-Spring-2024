using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyChaosSpring2024
{
    public class BedroomAudio : MonoBehaviour
    {
        public AudioSource waterDo;
        public AudioSource waterRe;
        public AudioSource waterMi;



        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void playAudio(int index){
            List<AudioSource> waterAudios = new List<AudioSource>(){waterDo, waterRe, waterMi};
            waterAudios[index].Play();
        }
    }
}
