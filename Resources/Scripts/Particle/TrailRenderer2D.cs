using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.Particle
{
    public class TrailRenderer2D : MonoBehaviour
    {
        public GameObject trailBase;
        public float trailSpeed = 0.5f;
        private SpriteRenderer sr;
        private bool createTrail = true;
        public void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            StartCoroutine(CreateTrail());
        }

        public IEnumerator CreateTrail()
        {
            while (createTrail)
            {
                GameObject trailObject = Instantiate(trailBase, transform.position, transform.rotation);
                SpriteRenderer trailSprite = trailObject.GetComponent<SpriteRenderer>();
                trailSprite.sprite = sr.sprite;
                trailSprite.flipX = sr.flipX;
                trailObject.AddComponent<TrailFade>();
                yield return new WaitForSeconds(trailSpeed);
            }
        }
    }
}
