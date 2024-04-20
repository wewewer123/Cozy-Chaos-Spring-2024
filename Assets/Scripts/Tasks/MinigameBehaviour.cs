using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyChaosSpring2024
{
    /*
        NOTE FOR DEVELOPERS
        ___________________

        This class is a listener to the BedroomController Singleton

        This script controls whether a minigame shouws up or closes

        THIS DOES NOT CONTROL DIRECTLY ANY GAME OBJECT FROM THE SCENE, that's 
        done in the TaskBehaviour script

        If you want to make, for example, the bed change its mesh, create 
        a separate script for any object that needs to change its mesh when
        a minigame is completed

        That implies to anything, if there is a separate particle system to play, create
        a separate script which plays particles when the task is completed.
     */
    public class MinigameBehabiour : TaskListener
    {
        public override void OnStart()
        {
            // TODO: Minigame should start
        }

        public override void OnComplete()
        {
            // TODO: Minigame should end
        }
    }
}
