using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyChaosSpring2024
{
    public class MouseDrag : MonoBehaviour
    {
        public float zDistance = 10;
        Camera maincamera;
        public event System.Action onDrop;
        public event System.Action onDrag;

        private void Awake(){
            enabled = false;
            maincamera = Camera.main;
        }

        private void OnEnable(){
            // get the distance between the object and the camera
            zDistance = Vector3.Distance(maincamera.transform.position, transform.position);

            // When started dragging call onDrag event
            if (onDrag != null)
                onDrag();
        }

        private void Update(){
            //after dragging the object, turn off this script (stop movment)
            if(Input.GetMouseButtonUp(0)){
                // Call event when dropped
                if (onDrop != null)
                    onDrop();

                enabled = false;
                return;
            }

            // get the mouse/ object target position
            Vector3 mousePos = Input.mousePosition;
            Vector3 dragPos = maincamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));

            // set the object to the new position
            transform.position = dragPos;

        }
    }
}
