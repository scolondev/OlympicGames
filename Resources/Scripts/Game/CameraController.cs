using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.Game
{
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        public float smoothSpeed;
        public Vector3 offset = new Vector3(0,1,-10);

        private Vector3 smoothedPosition;
        public void FixedUpdate()
        {
            smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed * Time.fixedDeltaTime);
        }

        public void LateUpdate()
        {
            transform.position = smoothedPosition;
        }
    }
}

