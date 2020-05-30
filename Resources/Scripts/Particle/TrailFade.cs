using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.Particle
{
    public class TrailFade : MonoBehaviour
    {
        public float fadeSpeed = 0.01f;
        private SpriteRenderer sr;
        public void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            StartCoroutine(Fade());
        }

        public IEnumerator Fade()
        {
            while(sr.color.a > 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - 0.02f);
                yield return new WaitForSeconds(fadeSpeed);
            }

            Destroy(this.gameObject);
        }
    }
}
