using System.Collections;
using System.Collections.Generic;
using CozyChaosSpring2024;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DragControl : MonoBehaviour
{

    public Transform mainCamera;
    public TodoListScriptable todoList;

    public GameObject closetTask;

    //obects that need sorting
    public GameObject heartShirt;
    public GameObject tealShorts;
    public GameObject jeans;
    public GameObject purplepants;
    public GameObject sunshirt;
    public GameObject frogshirt;
    public GameObject snowmanshirt;
    public GameObject weweshirt;
    public GameObject pinkshoes;
    public GameObject brownshoes;
    public GameObject flipflops;
    public GameObject pinkshorts;
    public GameObject redshorts;




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
                        //SceneManager.LoadScene(0);
                        todoList.todos["organize closet"] = true;
                        Camera.main.transform.SetPositionAndRotation(new Vector3(-5, 5 ,7), Quaternion.Euler(18,140,0));
                        closetTask.gameObject.SetActive(false);

                    }
                }
            }
        }
    }

    private bool checkOrder(){
        // add the positions in the right order

        //correct order (in X direction)
        // List<GameObject> correct_order = new List<GameObject> {heartShirt,tealShorts,jeans}; 
        // // check if that list is ordered
        // float previous = -10;
        // foreach (var obj in correct_order){
        //     var pos = obj.GetComponent<Transform>().position.x;
        //     if (pos > previous){
        //         previous = pos;
        //     }
        //     else{
        //         return false; // if the order is not correct then return false
        //     }
        // }

        // justthe vertical direction
        List<GameObject> topShirts = new List<GameObject> {heartShirt,sunshirt,snowmanshirt,weweshirt,frogshirt}; 
        List<GameObject> bottomPants = new List<GameObject> {tealShorts,jeans,purplepants,pinkshorts,redshorts}; 

        float lowestShirt = 50;
        foreach(var shirt in topShirts){
            if (lowestShirt > shirt.GetComponent<Transform>().position.y){
                lowestShirt = shirt.GetComponent<Transform>().position.y;
            }
        }
        float highestPants = -10;
        foreach(var pants in bottomPants){
            if (highestPants < pants.GetComponent<Transform>().position.y){
                highestPants = pants.GetComponent<Transform>().position.y;
            }
        }
        
        if (lowestShirt > highestPants){
            return true;
        }
        else{
            return false;
        }
        

        // return true;
    }
}

