using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace CozyChaosSpring2024
{
    public class SceneTransition : MonoBehaviour
    {

        [SerializeField] private GameObject bgPanel;
        [SerializeField] private GameObject textPanel;
        [SerializeField] private float textAppearDelay = 2.0f;
        [SerializeField] private KeyCode skipToGameKey = KeyCode.Space;




        private int nextSceneIndex;


        public void PlayTransition(int nextSceneIndex)
        {
            this.nextSceneIndex = nextSceneIndex;
            StartCoroutine(PlayEffect());
        }

        private IEnumerator PlayEffect()
        { 
           bgPanel.SetActive(true);
           yield return new WaitForSeconds(textAppearDelay);
           textPanel.SetActive(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(skipToGameKey)) LoadNextScene();
        }


        private void LoadNextScene()
        {
            
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
