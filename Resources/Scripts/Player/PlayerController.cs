using OlympicGames.Audio;
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
        private Animator animator;
        private bool jumpedOffRight;
        private bool jumpedOffLeft;

        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            ground = LayerMask.GetMask("Ground");
            animator = GetComponentInChildren<Animator>();
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
            if(input == -1) { transform.localScale = new Vector3(-1, 1, 1);  } else if (input == 1) { transform.localScale = new Vector3(1, 1, 1); }
            rb.AddForce(Vector2.right * input * moveSpeed, ForceMode2D.Force);

            //We don't want to be moving too fast.
            float clampedSpeed = Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed);
            rb.velocity = new Vector2(clampedSpeed, rb.velocity.y);

            //We don't want to decelerate when we are in the air.
            if (input == 0) { rb.velocity = new Vector2(rb.velocity.x * decelerationSpeed, rb.velocity.y); }

            animator.SetFloat("XSpeed", Mathf.Abs(rb.velocity.x));
            animator.SetFloat("YSpeed", Mathf.Abs(rb.velocity.y));
        }

        public void Jump()
        {
            if (IsTouchingGround()){
                rb.AddForce(jumpSpeed * Vector2.up, ForceMode2D.Impulse);
                animator.SetBool("Jump", true);
                AudioManager.instance.PlaySound("player_jump");
            }
        }

        public void JumpEnd()
        {
            animator.SetBool("Jump", false);
        }

        private bool IsTouchingGround()
        {
            return Physics2D.Raycast(transform.position, Vector2.down, 1f, ground);
        }

    }
}
