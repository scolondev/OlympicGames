using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.World
{
    public class Portal : MonoBehaviour
    {
        public Portal destination;
        public bool canTeleport = true;

        public void Refresh()
        {
            StartCoroutine(Cooldown());
        }
        public IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(1);
            canTeleport = true;
        }

        public void Teleport(GameObject obj)
        {
            destination.canTeleport = false;
            canTeleport = false;

            destination.Refresh();
            Refresh();

            obj.transform.position = destination.transform.position;
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(canTeleport)
            Teleport(collision.gameObject);
        }
    }
}

