using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyChaosSpring2024
{
    [RequireComponent(typeof(MouseDrag))]
    public class ClothingBehaviour : MonoBehaviour
    {
        [SerializeField] Sprite defaultSpr;
        [SerializeField] Sprite hangingSpr;
        [SerializeField] int correctHeight;
        public bool correct { get => dragController.relativeHeight[correctHeight] == transform.localPosition.y; }

        DragControl dragController;
        SpriteRenderer spr;

        float wiggle;

        // Start is called before the first frame update
        void Start()
        {
            spr = GetComponent<SpriteRenderer>();
            spr.sprite = defaultSpr;

            dragController = transform.parent.GetComponentInChildren<DragControl>();

            GetComponent<MouseDrag>().onDrag += OnDrag;
            GetComponent<MouseDrag>().onDrop += OnDrop;
        }

        private void Update()
        {
            if(spr.sprite == hangingSpr &&  wiggle > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.realtimeSinceStartup * 5) * wiggle);
                wiggle -= Time.deltaTime * 10f;
            }
        }

        private void OnDrag()
        {
            spr.sprite = defaultSpr;
            wiggle = 0;
        }

        void OnDrop()
        {
            AudioManager.i.PlayAudioByName("ClothesMoving");
            // Check if it's in between the bars
            if(Mathf.Abs( transform.localPosition.x) > 2.8f)
            {
                spr.sprite = defaultSpr;
                return;
            }

            // Clip clothes to the bars
            float reference = transform.localPosition.y;
            foreach(float h in dragController.relativeHeight)
            {
                if(transform.localPosition.y < h)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, h, 2);
                    spr.sprite = hangingSpr;
                    wiggle = 10;

                    if (dragController.relativeHeight[correctHeight] == h)
                        GetComponent<ParticleSystem>().Play();

                    return;
                }
            }

            
            
        }
    }
}
