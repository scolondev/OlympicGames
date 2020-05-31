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
            if (target == null) return;
            smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed * Time.fixedDeltaTime);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, -5.5f, float.MaxValue);
        }

        public void LateUpdate()
        {
            transform.position = smoothedPosition;
        }
    }
}

