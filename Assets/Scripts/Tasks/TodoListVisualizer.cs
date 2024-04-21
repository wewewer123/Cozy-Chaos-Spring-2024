using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CozyChaosSpring2024
{
    public class TodoListVisualizer : MonoBehaviour
    {
        private TextMeshProUGUI text;
        public TodoListScriptable todos;

        public Sprite filledCheckBox;
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
            int i = 0;
            foreach (var task in todos.todos.Keys){
                // print(task);
                if (todos.todos[task] == true){
                    text.text = text.text + "\n" + task;
                    this.transform.GetChild(i).GetComponent<Image>().sprite = filledCheckBox; //update teh check box to checked
                }
                else{
                    text.text = text.text + "\n" + task;
                }
                i += 1;

            }
        }
    }
}
