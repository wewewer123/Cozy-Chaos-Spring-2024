using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyChaosSpring2024
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private List<Vector3> roomPosList;
        private bool isMoving;
        private int moveTarget;
        private bool wasZoomed = false;
        private float zoomAmount = 4;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                MoveCamera(0);
                //Zoom(true);
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                MoveCamera(1);
                //Zoom(false);
            }
        }
        private void FixedUpdate()
        {
            SmoothZoom();
            SmoothMove();
        }

        private void SmoothMove()
        {
            if (isMoving)
            {
                if (transform.position == roomPosList[moveTarget])
                {
                    isMoving = false;
                    moveTarget = -1;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, roomPosList[moveTarget], 0.1f);
                }
            }
        }

        private void SmoothZoom()
        {
            this.GetComponent<Camera>().orthographicSize = Mathf.MoveTowards(this.GetComponent<Camera>().orthographicSize, zoomAmount, 0.1f);
        }

        public void MoveCamera(int roomNumber)
        {
            isMoving = true;
            moveTarget = roomNumber;
        }

        public void Zoom(bool isZoomed)
        {
            if(isZoomed && !wasZoomed)
            {
                zoomAmount = 2;
                wasZoomed = true;
            }
            if(!isZoomed && wasZoomed)
            {
                zoomAmount = 4;
                wasZoomed = false;
            }
        }
    }
}
