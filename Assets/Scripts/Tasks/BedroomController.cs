using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CozyChaosSpring2024;


namespace CozyChaosSpring2024
{
    public class BedroomController : MonoBehaviour
    {
        public Transform mainCamera;

        public GameObject madeBed;

        // Start is called before the first frame update
        void Start()
        {
            mainCamera = Camera.main.transform;
            madeBed.GetComponent<MeshRenderer>().enabled = false;
        }

        // Update is called once per frame
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
                        // SceneManager.LoadScene("Closet Sorting Minigame");
                        SceneManager.LoadScene(1);
                    }
                    if(objectName == "bed"){
                        print("got here");
                        // SceneManager.LoadScene("Closet Sorting Minigame");
                        target.GetComponent<MeshRenderer>().enabled = false;
                        madeBed.GetComponent<MeshRenderer>().enabled = true;
                    }
                    if(objectName == "smallRug" || objectName == "largeRug" ){
                        print("got here");
                        SceneManager.LoadScene(2);
                    }
                    

                }
            }
        }
    }
}
