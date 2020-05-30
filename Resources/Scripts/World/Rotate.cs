using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.World {
    public class Rotate : MonoBehaviour
    {
        public float rotateSpeed;
        public void Update()
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + rotateSpeed * Time.deltaTime);
        }
    }
}

