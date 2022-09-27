using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
   public float movePower = 10f;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        private bool isDead;
        Vector3 movement;
        bool doubleJump;
        private float horizontalMovement;
        private Vector3 respawnPosition;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask deadCheckLayer;

        // Start is called before the first frame update
        void Start()
        {
            respawnPosition = transform.position;
            isDead = false;
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.15f);
        }

        private void Update()
        {
            if (!IsDead())
            {
                if (GameManager.disableInput)
                {
                    return;
                }
                if (IsGrounded()) 
                {
                    doubleJump = true;    
                }
                horizontalMovement = Input.GetAxisRaw("Horizontal");
                Jump();
            }      
            else
            {
                transform.position = respawnPosition;
                isDead = false;
            }
        }

        private void FixedUpdate()
        {
            if (!IsDead() && !GameManager.disableInput)
            {
                Run();
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);
        }

        private bool IsDead()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, deadCheckLayer) || isDead;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            GameObject obj = col.gameObject;
            Debug.Log(obj);
            if (obj.tag == "Obstacle")
            {
                isDead = true;
            } else if (obj.tag == "CheckPoint")
            {
                respawnPosition = obj.transform.position;
                obj.GetComponent<SpriteRenderer>().color = Color.green;
                obj.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            Vector3 localScale = transform.localScale;

            if (horizontalMovement < 0)
            {
                moveVelocity = Vector3.left;
                
                if(localScale.x > 0) {
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                }
            }
            if (horizontalMovement > 0)
            {
                moveVelocity = Vector3.right;
                 if(localScale.x < 0) {
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                }
            }
            transform.position += moveVelocity * (movePower * Time.fixedDeltaTime);
        }

        void Jump()
        {
            if ((Input.GetButtonDown("Jump")))
            {
                if (IsGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                } else if (doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                    doubleJump = false;
                }

            }
        }
}