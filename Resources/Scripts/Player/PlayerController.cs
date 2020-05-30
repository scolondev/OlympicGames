using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Horizontal Movement")]
        public float moveSpeed;
        public float maxMoveSpeed;
        public float decelerationSpeed = 0.85f;
        [Header("Vertical Movement")]
        public float jumpSpeed;
        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;

        private Rigidbody2D rb;
        private LayerMask ground;
        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            ground = LayerMask.GetMask("Ground");
        }

        public void FixedUpdate()
        {
            float inputx = Input.GetAxisRaw("Horizontal");
            float inputy = Input.GetAxisRaw("Vertical");

            Move(inputx);
            if(inputy == 1)
            {
                Jump();
            }

            //Less floaty jumps - movement should be snappy
            if(rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
            } else if (rb.velocity.y > 0 && inputy != 1)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
            }
        }

        public void Move(float input)
        {
            rb.AddForce(Vector2.right * input * moveSpeed, ForceMode2D.Force);

            //We don't want to be moving too fast.
            float clampedSpeed = Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed);
            rb.velocity = new Vector2(clampedSpeed, rb.velocity.y);

            //We don't want to decelerate when we are in the air.
            if (input == 0) { rb.velocity = new Vector2(rb.velocity.x * decelerationSpeed, rb.velocity.y); }
        }

        public void Jump()
        {
            if (IsTouchingGround())
                rb.AddForce(jumpSpeed * Vector2.up, ForceMode2D.Impulse);
        }

        private bool IsTouchingGround()
        {
            return Physics2D.Raycast(transform.position, Vector2.down, 1f, ground);
        }
    }
}
