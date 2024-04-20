using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyChaosSpring2024
{
    /*
        NOTE FOR DEVS
    
    This script is an abstract class

    That means you can create different scripts for different properties 
    that must be changed from the enviroment on the completion of a task

    An example could be a reference to a component

     */
    public abstract class TaskListener: MonoBehaviour
    {
        [SerializeField] string taskName = "Default";

        private void Start()
        {
            BedroomController.i.onMinigameStart += OnMinigameStart;
            BedroomController.i.onMinigameComplete += OnMinigameEnd;
        }

        void OnMinigameStart(string task)
        {
            if (taskName == "Default")
                Debug.LogWarning($"Task from {gameObject.name} has its name set to default, please make sure to change it");

            if (taskName == task)
            {
                OnStart();
            }
        }

        void OnMinigameEnd(string task)
        {
            if (taskName == "Default")
                Debug.LogWarning($"Task from {gameObject.name} has its name set to default, please make sure to change it");

            if (taskName == task)
            {
                OnComplete();
            }
        }

        public abstract void OnStart();
        public abstract void OnComplete();
    }
}
