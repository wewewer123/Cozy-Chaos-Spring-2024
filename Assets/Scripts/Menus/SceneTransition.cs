using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace CozyChaosSpring2024
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private int numberOfSpawns;
        [SerializeField] private float delayBetweenSpawns;
        [SerializeField] private Sprite[] images;
        
        private BoxCollider2D _spawnArea;
        

        private void Awake()
        {
            _spawnArea = GetComponent<BoxCollider2D>();
        }

        void Start()
        {
            // StartCoroutine(PlayEffect(1));
        }

        public void PlayTransition(int nextSceneIndex)
        {
            StartCoroutine(PlayEffect(nextSceneIndex));
        }

        private IEnumerator PlayEffect(int nextSceneIndex)
        { 
            int currCount = numberOfSpawns;
           while (currCount > 0)
           {
               Spawn();
               currCount--;
               yield return new WaitForSeconds(delayBetweenSpawns);
           }

           SceneManager.LoadScene(nextSceneIndex);
           ReverseEffect();
        }
        

        private void ReverseEffect()
        {
            foreach (var spawn in spawns)
            {
                var randomAngle = Random.Range(0f, Mathf.PI);
                var randomDirection = new Vector3(MathF.Cos(randomAngle), MathF.Sin(randomAngle), 0);
                var endPosition = spawn.transform.position + (randomDirection * 30);
                spawn.transform.DOMove(endPosition, 2f);
            }
            
        }

        private List<GameObject> spawns = new List<GameObject>();

        private void Spawn()
        {
            var go = new GameObject();
            spawns.Add(go);
            go.transform.position = GetRandomPosition();
            go.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            go.transform.localScale = new Vector3(5, 5, 0);
            go.transform.parent = gameObject.transform;
            var spriteRenderer = go.AddComponent<SpriteRenderer>();
            var sprite = GetRandomSprite();
            spriteRenderer.sprite = sprite;
            AudioManager.i.PlayAudioByName("Pop");
        }

        private Sprite GetRandomSprite()
        {
            var index = Random.Range(0, images.Length);
            return images[index];
        }

        private Vector3 GetRandomPosition()
        {
            var boundsCenter = _spawnArea.bounds.center;
            var boundsExtents = _spawnArea.bounds.extents;
            // var areas = _spawnArea.bounds.extents;
            // var x = Random.Range(-areas.x, areas.x);
            // var y = Random.Range(-areas.y, areas.y);
            var randomPosition = new Vector3(
                Random.Range(boundsCenter.x - boundsExtents.x, boundsCenter.x + boundsExtents.x),
                Random.Range(boundsCenter.y - boundsExtents.y, boundsCenter.y + boundsExtents.y),
               0
            );
            return randomPosition;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
