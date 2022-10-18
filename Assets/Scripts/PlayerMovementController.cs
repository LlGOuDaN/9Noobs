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
        private bool isDead;
        private Vector3 respawnPosition;
        public bool gravityMode;
        public float darkWorldGravityScale;
        public float lightWorldGravityScale;

        //for PM analytics
        SendToGoogle STG;
        public bool data_sent = false;
        public static int scene_id;
        public static float t;
        public static float t_initial;
        
        

        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask deadCheckLayer;

        // Start is called before the first frame update
        void Start()
        {
            t = Time.time;

            t_initial = t;
            rb = GetComponent<Rigidbody2D>();
            isDead = false;
            respawnPosition = transform.position;
            if (gravityMode)
            {
                GetComponent<Rigidbody2D>().gravityScale = darkWorldGravityScale;
            }
            anim = GetComponent<Animator>();
            GameManager.disableInput = false;
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
                    anim.SetBool("isJump", false);
                }
                else
                {
                    anim.SetBool("isJump", true);
                }
                horizontalMovement = Input.GetAxisRaw("Horizontal");
                Jump();
                if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        GetComponent<SpriteRenderer>().color = Color.white;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = Color.black;
                    }
                }
                
                if (gravityMode)
                {
                    if (GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        GetComponent<Rigidbody2D>().gravityScale = darkWorldGravityScale;
                    } else if (GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        GetComponent<Rigidbody2D>().gravityScale = lightWorldGravityScale;
                    }
                }
            }      
            else
            {
                GameManager.disableInput = true;
                //if player dead, send to google form
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Respawn();
                }
                if (!data_sent)
                {
                    try
                    {
                        scene_id = Int32.Parse(SceneManager.GetActiveScene().name);
                        STG = FindObjectOfType<SendToGoogle>();
                        STG.Send(scene_id, false, Time.time - t,Time.time-t_initial);
                        SendToGoogle.dead_num += 1;
                        t = Time.time;
                    }
                    catch (Exception e)
                    {
                        // skip sent 
                        Console.WriteLine(e);
                    }
                    data_sent = true;
                }
                
                anim.SetBool("isDead", true);
                rb.velocity = new Vector2(0,0);
            }
        }

        private void Respawn()
        {
            if (isDead)
            {
                anim.Play("Idle");
                transform.position = respawnPosition;
                isDead = false;
                data_sent = false;
                GameManager.disableInput = false;
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
            return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }

        private bool IsDead()
        {
            return isDead;
        }

        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            Vector3 localScale = transform.localScale;

            if (horizontalMovement < 0)
            {
                if(!anim.GetBool("isJump"))
                {
                    anim.SetBool("isRun", true);
                }
                
                moveVelocity = Vector3.left;
                
                if(localScale.x > 0) {
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                }
            }
            if (horizontalMovement > 0)
            {
                if(!anim.GetBool("isJump"))
                {
                    anim.SetBool("isRun", true);
                }
                moveVelocity = Vector3.right;
                 if(localScale.x < 0) {
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                }
            }

            if (horizontalMovement == 0)
            {
                anim.SetBool("isRun", false);
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

        private void OnCollisionEnter2D(Collision2D col)
        {
            GameObject obj = col.gameObject;
            if (obj.tag == "Obstacle")
            {
                isDead = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            GameObject obj = col.gameObject;
            if (obj.tag == "CheckPoint")
            {
                respawnPosition = obj.transform.position;
                obj.GetComponent<SpriteRenderer>().color = Color.green;
                obj.GetComponent<BoxCollider2D>().enabled = false;
            } else if (obj.layer == LayerMask.NameToLayer("DeadCheckLayer"))
            {
                isDead = true;
            }
        }
        
        public float getT()
        {
            return t;
        }

        public float getTInitial()
        {
            return t_initial;
        }
}