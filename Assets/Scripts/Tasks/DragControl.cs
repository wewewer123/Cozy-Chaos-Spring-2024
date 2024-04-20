using System.Collections;
using System.Collections.Generic;
using CozyChaosSpring2024;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DragControl : MonoBehaviour
{

    public Transform mainCamera;

    //obects that need sorting
    public GameObject red;
    public GameObject blue;
    public GameObject green;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
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
                    print("I have hit a not draggable object");
                }
            }

        }
        if (Input.GetMouseButtonUp(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if(Physics.Raycast(ray, out hit, 1000)){
                //if we have hit an object with the ray
                MouseDrag mDrag = hit.collider.GetComponent<MouseDrag>();
                if(mDrag){
                    print(checkOrder());
                    if(checkOrder()){
                        //if the order is correct then close out to the main game
                        SceneManager.LoadScene(0);
                    }
                }
            }
        }
    }

    private bool checkOrder(){
        // add the positions in the right order
        float redX = red.GetComponent<Transform>().position.x;
        float greenX = green.GetComponent<Transform>().position.x;
        float blueX = blue.GetComponent<Transform>().position.x;

        List<float> correct_order = new List<float> {redX,greenX,blueX};
        // check if that list is ordered
        float previous = -10;
        foreach (float pos in correct_order){
            if (pos > previous){
                previous = pos;
            }
            else{
                return false; // if the order is not correct then return false
            }
        }

        return true;
    }
}

