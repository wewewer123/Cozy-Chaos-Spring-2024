using System;
using System.Collections;
using System.Collections.Generic;
using CozyChaosSpring2024;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrazyChaosSpring2024
{
    public class MainMenuManager : MonoBehaviour
    {
        private UIAnimation[] _uiAnimationsElements;

        private void Awake()
        {
            _uiAnimationsElements = FindObjectsByType<UIAnimation>(FindObjectsSortMode.None);
        }

        public void OnPlay()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void OnOptionsClicked()
        {
            foreach (var uiElem in _uiAnimationsElements)
            {
                uiElem.Shrink();
            }
        }

        public void OnCreditsClicked()
        {
            
        }
    }
}
