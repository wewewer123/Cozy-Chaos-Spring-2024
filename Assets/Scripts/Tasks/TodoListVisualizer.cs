using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CozyChaosSpring2024
{
    public class TodoListVisualizer : MonoBehaviour
    {
        private TextMeshProUGUI text;
        public TodoListScriptable todos;
        // Start is called before the first frame update
        void Start()
        {
            text = this.GetComponent<TextMeshProUGUI>();
            updateTodoList();
        }

        // Update is called once per frame
        void Update()
        {
            updateTodoList();
            // print(todos.todos.Keys);
        }

        private void updateTodoList(){
            text.text = "Todo List";
            foreach (var task in todos.todos.Keys){
                // print(task);
                if (todos.todos[task] == true){
                    text.text = text.text + "\n" + "check -" + task;
                }
                else{
                    text.text = text.text + "\n" + "x -" + task;
                }
                
                // print(task);
            }
        }
    }
}
