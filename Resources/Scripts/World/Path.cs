using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.World {
    public class Path : MonoBehaviour
    {
        private Vector2 currentDestination = Vector2.zero;
        public Vector2[] points;
        public float timeOffset = 0;
        public float waitTime = 3;
        public float lerpTime = 1;

        public void Start()
        {
            for(int i = 0; i < points.Length; i++)
            {
                points[i] = new Vector2(transform.position.x,transform.position.y) + points[i];
            }

            StartCoroutine(StartFollowing());
        }

        public void Update()
        {
            if (currentDestination != Vector2.zero)
            { 
                transform.position = Vector2.Lerp(transform.position, currentDestination, lerpTime * Time.deltaTime);
            }
        }

        public IEnumerator StartFollowing()
        {
            yield return new WaitForSeconds(timeOffset);
            StartCoroutine(FollowPath());
        }

        public IEnumerator FollowPath()
        {
            int point = 0;
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                currentDestination = points[point];
                point++;
                if(point >= points.Length) { point = 0; }
            }
        }
    }
}

