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
        private Dictionary<string,bool> taskbools = new Dictionary<string,bool>{{"make bed",false}, {"organize closet",false}, {"fix rugs",false}, {"open curtains",false}, {"water plants",false}};


        public GameObject messyBed;
        public GameObject neatBed;

        public GameObject openDoor;
        public GameObject closeDoor;
        private List<bool> curtains = new List<bool>(){false,false,false,false};

        public Light light1;
        public Light light2;
        public Light mainLight;
        public static BedroomController i;

        public GameObject ClosetTask;

        public GameObject RugTask;

        private int waterClicks = 0;

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
            // // Check if instance already exists
            // if (i == null)
            // {
            //     // If not, set instance to this
            //     i = this;
            // }
            // // If instance already exists and it's not this:
            // else if (i != this)
            // {
            //     // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a Singleton.
            //     // Destroy(gameObject);
            // }

            // // Sets this to not be destroyed when reloading scene
            // DontDestroyOnLoad(gameObject);
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
                    // print(objectName);

                    if(objectName == "wardrobe"){
                        //SceneManager.LoadScene("Closet Sorting Minigame");
                        //SceneManager.LoadScene(1);
                        Camera.main.transform.SetPositionAndRotation(new Vector3(0, 10 ,0), Quaternion.Euler(0,180,0));
                        // Camera.main.orthographicSize = 7;
                        ClosetTask.SetActive(true);
                    }
                    
                    if(objectName == "Bed" || objectName == "ComforterTidy" || objectName == "ComforterMessy"){
                        // SceneManager.LoadScene("Closet Sorting Minigame");
                        // target.GetComponent<MeshRenderer>().enabled = false;
                        // target.GetComponentInChildren<MeshRenderer>().enabled = true;
                        messyBed.GetComponent<MeshRenderer>().enabled = false;
                        neatBed.GetComponent<MeshRenderer>().enabled = true;
                        todoList.todos["make bed"] = true;
                    }
                    
                    if(objectName == "smallRug" || objectName == "largeRug" ){
                        Camera.main.transform.SetPositionAndRotation(new Vector3(-0.5f, 10.75f ,1.15f), Quaternion.Euler(90,90,0));
                        // Camera.main.orthographicSize = 3;
                        RugTask.SetActive(true);
                        // SceneManager.LoadScene(2);
                    }

                    if(objectName == "curtain1a" || objectName == "curtain1b" || objectName == "curtain2a" || objectName == "curtain2b"){

                        if(objectName == "curtain1a"){
                            target.transform.localScale = new Vector3(4.627653f,2.5f,4.627653f);
                            target.transform.position = new Vector3(target.transform.position.x,target.transform.position.y,1.5f);
                            curtains[0] = true;
                        }
                        if(objectName == "curtain1b"){
                            target.transform.localScale = new Vector3(4.627653f,2.5f,4.627653f);
                            curtains[1] = true;
                        }
                        if(objectName == "curtain2a"){
                            target.transform.localScale = new Vector3(2.5f,4.627653f,4.627653f);
                            curtains[2] = true;
                        }
                        if(objectName == "curtain2b"){
                            target.transform.localScale = new Vector3(2.5f,4.627653f,4.627653f);
                            target.transform.position = new Vector3(-.5f,2.743543f,-2.623531f);
                            curtains[3] = true;
                        }
                        // if curtain 1 a and b then turn that window light on
                        if(curtains[0] && curtains[1]){
                            //turnon light
                            light1.GetComponent<Light>().enabled = true;                       
                        }
                        // if curtian 2 a and 2b then turn that light on
                        if(curtains[2] && curtains[3]){
                            //turnon light  
                            light2.GetComponent<Light>().enabled = true;                       
                        }

                        //if all curtains are open then say the task is complete
                        if(curtains.Contains(false) == false){
                            mainLight.GetComponent<Light>().intensity = 40;
                            todoList.todos["open curtains"] = true;
                        }
                        
                    }

                    if(objectName == "WateringCan"){
                        waterClicks += 1;
                        if (waterClicks == 3){
                            todoList.todos["water plants"] = true;
                        }
                        else if(waterClicks > 3){
                            print("You have failed the water Task");
                            // do whatever we want on the failure of the watering task
                        }
                    }

                    if(objectName == "Door" || objectName == "DoorClosed"){
                         bool done = todoList.checkCompletion();
                         if(done){
                             print("you can leave now");
                             // move to the end epilouge scene
                            SceneManager.LoadScene(3);
                         }
                         else{
                             print("make sure you have finished all tasks");
                         }
                     }
                }
            }

            if (todoList.checkCompletion()){
                // cahnge the door to be open when all tasks are done
                closeDoor.GetComponent<MeshRenderer>().enabled = false;
                openDoor.GetComponent<MeshRenderer>().enabled = true;
            }   
        }
    }
}
