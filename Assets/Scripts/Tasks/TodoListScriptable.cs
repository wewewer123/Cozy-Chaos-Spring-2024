using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyChaosSpring2024
{
    [CreateAssetMenu()]
    public class TodoListScriptable : ScriptableObject
    {
        public Dictionary<string,bool> todos = new Dictionary<string,bool>(); 

        public int taskNumber;

        public string task1;

        public bool checkCompletion(){
            foreach(var task in todos.Keys){
                if(todos[task] == false){
                    return false;
                }
            }
            return true;
        }

    }
}
