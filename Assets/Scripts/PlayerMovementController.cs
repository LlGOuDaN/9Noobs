using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
   public float movePower = 10f;
        public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        bool doubleJump;
        private float horizontalMovement;

        //for PM analytics
        SendToGoogle STG;
        public bool data_sent = false;
        public static int scene_id;
        public static float t;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask deadCheckLayer;

        // Start is called before the first frame update
        void Start()
        {
            t = Time.time;
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
                if (!data_sent){//if player dead, send to google form
                scene_id = Int32.Parse(SceneManager.GetActiveScene().name);
                t = Time.time -t;

                STG = FindObjectOfType<SendToGoogle>();
                STG.Send(scene_id,false,t);
                data_sent = true;

                SendToGoogle.dead_num +=1;}

                Invoke(nameof(RestartLevel), 0.5f);
            }
        }

        private void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, deadCheckLayer);
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