using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CozyChaosSpring2024;
using Unity.Mathematics;


namespace CozyChaosSpring2024
{
    public class BedroomController : MonoBehaviour
    {
        // objects needed for Ray casting - this was removed when we moved to the one scne thing but Im not sure why bc we still need to click?
        // public Transform mainCamera;

        //objects for todolist
        public TodoListScriptable todoList;
        private Dictionary<string,bool> taskbools = new Dictionary<string,bool>{{"make bed",false}, {"organize closet",false}, {"fix rugs",false}};

        public static BedroomController i;

        public GameObject ClosetTask;

        /// <summary>
        /// Event called when a minigame must show up
        /// </summary>
        public event System.Action<string> onMinigameStart;
        /// <summary>
        /// When a minigame is completed, this event is called
        /// </summary>
        public event System.Action<string> onMinigameComplete;

        // Awake is always called before any Start functions
        void Awake()
        {
            // Check if instance already exists
            if (i == null)
            {
                // If not, set instance to this
                i = this;
            }
            // If instance already exists and it's not this:
            else if (i != this)
            {
                // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a Singleton.
                Destroy(gameObject);
            }

            // Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }

        void Start(){
            // mainCamera = Camera.main.transform;
            // madeBed.GetComponent<MeshRenderer>().enabled = false;

            todoList.todos = taskbools;
        }
        // Update handles input
        void Update()
        {
            //when we click down the mouse, and it hits a game object, start the drag
            if(Input.GetMouseButtonDown(0)){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if(Physics.Raycast(ray, out hit, 1000)){
                    //if we have hit an object with the ray
                    MouseDrag mDrag = hit.collider.GetComponent<MouseDrag>();
                    if(mDrag){
                        mDrag.enabled = true; // if there is a mouse grag on the object then drag it
                    }
                    else{
                        // print("I have hit a not draggable object");
                    }
                }

            }
            if (Input.GetMouseButtonUp(0)){
                // if you want to do anything on let go
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if(Physics.Raycast(ray, out hit, 1000)){
                    //if we have hit an object with the ray
                    GameObject target = hit.collider.gameObject;
                    string objectName = target.name;
                    print(objectName);

                    if(objectName == "wardrobe"){
                        //SceneManager.LoadScene("Closet Sorting Minigame");
                        //SceneManager.LoadScene(1);
                        Camera.main.transform.SetPositionAndRotation(new Vector3(0, 10 ,0), Quaternion.Euler(0,180,0));
                        Camera.main.orthographicSize = 7;
                        ClosetTask.SetActive(true);
                    }
                    if(objectName == "bed"){
                        print("got here");
                        // SceneManager.LoadScene("Closet Sorting Minigame");
                        target.GetComponent<MeshRenderer>().enabled = false;
                        target.GetComponentInChildren<MeshRenderer>().enabled = true;
                        todoList.todos["make bed"] = true;
                    }
                    if(objectName == "smallRug" || objectName == "largeRug" ){
                        print("got here");
                        SceneManager.LoadScene(2);
                    }
                     if(objectName == "door"){
                         bool done = todoList.checkCompletion();
                         if(done){
                             print("you can leave now");
                             // move to the end epilouge scene
                         }
                         else{
                             print("make sure you have finished all tasks");
                         }
                     }

                    //if(objectName == "wardrobe"){
                    //    // SceneManager.LoadScene("Closet Sorting Minigame");
                    //     // SceneManager.LoadScene(1);
                    //     Camera.main.transform.SetPositionAndRotation(new Vector3(0,5,0), Quaternion.Euler(0,180,0));
                    //     Camera.main.orthographicSize = 2;
                    // }
                    //if(objectName == "bed"){
                    //    print("got here");
                    //    // SceneManager.LoadScene("Closet Sorting Minigame");
                    //    target.GetComponent<MeshRenderer>().enabled = false;
                    //    madeBed.GetComponent<MeshRenderer>().enabled = true;
                    //      todoList.todos["make bed"] = true;
                    //}
                    //if(objectName == "smallRug" || objectName == "largeRug" ){
                    //    print("got here");
                    //    SceneManager.LoadScene(2);
                    //}
                    // if(objectName == "door"){
                    //     bool done = todoList.checkCompletion();
                    //     if(done){
                    //         print("you can leave now");
                    //         // move to the end epilouge scene
                    //     }
                    //     else{
                    //         print("make sure you have finished all tasks");
                    //     }
                    // }



                }
            }
        }
    }
}
