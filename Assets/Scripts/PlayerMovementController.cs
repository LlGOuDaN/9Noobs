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
    private bool invincible;
    private Vector3 respawnPosition;
    private Vector3 respawnPositionInitial;
    public bool gravityMode;
    public float darkWorldGravityScale;
    public float lightWorldGravityScale;

    //for PM analytics
    SendToGoogle STG;
    public bool data_sent = false;
    public static int scene_id;
    public static float t;
    public static float t_initial;
    public static decimal xPosition;
    public static float progress;

    public static float maxHeight;
     
    public static int jumpNum;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask deadCheckLayer;
    [SerializeField] private AudioSource switchSFX;
    [SerializeField] private AudioSource lightWorldBGM;
    [SerializeField] private AudioSource darkWorldBGM;


    [SerializeField] private TrailRenderer tr;

    public GameObject deathNoteUI;

    // Start is called before the first frame update
    void Start()
    {
        maxHeight = transform.position.y;
        jumpNum = 0;
        t = Time.time;

        t_initial = t;
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
        invincible = false;
        respawnPosition = transform.position;
        respawnPositionInitial = transform.position;
        if (gravityMode)
        {
            GetComponent<Rigidbody2D>().gravityScale = darkWorldGravityScale;
        }

        anim = GetComponent<Animator>();
        GameManager.disableInput = false;
        deathNoteUI.SetActive(false);
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

            if(WorldSwitchController.isSwitch)
            {
                switchSFX.Play();
                darkWorldBGM.mute = lightWorldBGM.mute;
                lightWorldBGM.mute = !lightWorldBGM.mute;
                
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
                }
                else if (GetComponent<SpriteRenderer>().color == Color.white)
                {
                    GetComponent<Rigidbody2D>().gravityScale = lightWorldGravityScale;
                }
            }

            if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(Dash());
            }
        }
        else
        {
            GameManager.disableInput = true;
            

            //if player dead, send to google form
            if (!data_sent)
            {
                try
                {
                    float lengthOfMap = EndTrigger.end_x - respawnPositionInitial[0];
                    float heightOfMap = respawnPositionInitial[1] - EndTrigger.end_y;
                    //recording/calculating progress
                    scene_id = Int32.Parse(SceneManager.GetActiveScene().name);
                    if (scene_id == 4)
                    {
                        progress = (respawnPositionInitial[1] - transform.position[1]) / heightOfMap;
                    }
                    else
                    {
                        progress = (transform.position[0] - respawnPositionInitial[0]) / lengthOfMap;
                    }
                    Debug.Log(transform.position);
                    Debug.Log("NMSL");
                    Debug.Log(respawnPosition);

                    STG = FindObjectOfType<SendToGoogle>();
                    STG.Send(scene_id, false, Time.time - t, Time.time - t_initial, progress: progress);
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

            rb.velocity = new Vector3(0, 0,0);

            Invoke("showDeathNote", 1);

            if (Input.GetKeyDown(KeyCode.R) && !GameManager.disbaleRespawn)
            {
                Respawn();
            }
        }
    }


    private void Respawn()
    {
        if (isDead)
        {
            anim.Play("Idle");
            transform.position = respawnPosition;
            Debug.Log("This is Respawn");
            isDead = false;
            data_sent = false;
            GameManager.disableInput = false;
            GameManager.disbaleRespawn = true;
            deathNoteUI.SetActive(false);
            invincible = true;
            Invoke("RestoreInvincible", 1);
        }
    }

    private void RestoreInvincible()
    {
        invincible = false;
    }
    private void FixedUpdate()
    {
        var h = transform.position.y;
        if (h > maxHeight)
        {
            maxHeight = h;
        }

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
            if (!anim.GetBool("isJump"))
            {
                anim.SetBool("isRun", true);
            }

            moveVelocity = Vector3.left;

            if (localScale.x > 0)
            {
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }

        if (horizontalMovement > 0)
        {
            if (!anim.GetBool("isJump"))
            {
                anim.SetBool("isRun", true);
            }

            moveVelocity = Vector3.right;
            if (localScale.x < 0)
            {
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
                jumpNum++;
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            else if (doubleJump)
            {
                jumpNum++;
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

        if (obj.tag == "Saw")
        {
            isDead = true;
        }

        if(obj.tag == "Monster")
        {
            if(groundCheck.transform.position.y > col.transform.position.y) {
                obj.GetComponent<Monster>().Die();
            }
            else {
                if (!invincible)
                {
                    isDead = true;    
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;
        if (obj.tag == "Coins")
        {
            Destroy(obj);
        }
        
        if (obj.tag == "CheckPoint")
        {
            respawnPosition = obj.transform.position;
            obj.GetComponent<SpriteRenderer>().color = Color.green;
            obj.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (obj.layer == LayerMask.NameToLayer("DeadCheckLayer"))
        {
            isDead = true;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity=rb.gravityScale;
        rb.gravityScale=0f;
        rb.velocity=new Vector2(transform.localScale.x*dashingPower, 0f);
        tr.emitting =true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting=false;
        rb.gravityScale=originalGravity;
        isDashing=false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash=true;
    }

    public float getT()
    {
        return t;
    }

    public float getTInitial()
    {
        return t_initial;
    }

    void showDeathNote() {
        if (isDead) {
            deathNoteUI.SetActive(true);
        }
        
    }
}