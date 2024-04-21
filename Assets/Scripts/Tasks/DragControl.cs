using System.Collections;
using System.Collections.Generic;
using CozyChaosSpring2024;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DragControl : MonoBehaviour
{
    [SerializeField] float[] _relativeHeight;
    public float[] relativeHeight { get => _relativeHeight; }

    public Transform mainCamera;
    public TodoListScriptable todoList;

    public GameObject closetTask;

    //obects that need sorting
    [SerializeField] List<GameObject> shirts;
    [SerializeField] List<GameObject> pants;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        foreach(float h in relativeHeight)
        {
            Gizmos.DrawSphere(transform.parent.position + Vector3.up * h, 0.5f);
        }
    }


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
                    
                }
            }
            Invoke(nameof(checkOrder), Time.deltaTime * 2);
        }
    }

    private void checkOrder(){
        foreach(GameObject shirt in shirts){
            if (shirt.transform.localPosition.y != relativeHeight[1]){
                print("Incorrect shirt");
                return;
            }
        }
        foreach(GameObject pants in pants){
            if (pants.transform.localPosition.y != relativeHeight[0])
            {
                print("Incorrect pants");
                return;
            }
        }

        todoList.todos["organize closet"] = true;
        Camera.main.transform.SetPositionAndRotation(new Vector3(-5, 5, 7), Quaternion.Euler(18, 140, 0));
        closetTask.gameObject.SetActive(false);
    }
}

