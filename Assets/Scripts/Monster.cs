using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : MonoBehaviour
{
    public float speed = 2;
    public double moveTime = 1;
    private Animator anim;
    private bool directionRight;
    private float timer;
    private bool isDead;
    private bool isIdle;
    private GameObject player;
    private GameObject darkLight;
    private SpriteRenderer renderer;
    private Rigidbody2D rb;


    private float x;
    private float y;
    private Vector3 player_postion;
    private Vector3 monster_position;
    private double distance;

    private bool monster_isWhite;

    private float monster_height;

    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        isDead = false;
        // at start the monster is in Idle state;
        anim.SetBool("isMove", false);
        anim.SetBool("isDead", false);
        anim.SetBool("isIdle",true);
        renderer = gameObject.GetComponent<SpriteRenderer>();

        // disable rigidbody at first, otherwise it may fall
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        // record the monster color and start height.
        monster_isWhite = renderer.color == Color.white ? true : false; 
        monster_height = this.transform.position.y;
        

    }

    // Update is called once per frame
    void Update()
    {

        if(isDead) return;

        // if the monster is falling, die.
        if(monster_height - this.transform.position.y > 5.0f){
            Die();
            return;
        }
        
        // if the monster is in other world, turn in Idle state, disable rigidbody.
        if(monster_isWhite ^ GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().color == Color.white ){
            anim.SetBool("isMove", false);
            anim.SetBool("isIdle",true);
            rb.isKinematic = true;
            
            return;
        }        

        // calculate the distance between player and the monster
        player_postion = player.transform.position;
        monster_position = this.transform.position;
        x = player_postion.x - monster_position.x;
        y = player_postion.y - monster_position.y;
        distance = System.Math.Sqrt(x*x + y*y);
        
        // if the player is close enough, start moving.
        if(distance > 7.0){
            anim.SetBool("isMove", false);
            anim.SetBool("isIdle",true);
            return;
        }
        else{
            anim.SetBool("isIdle",false);
            anim.SetBool("isMove", true);
            rb.isKinematic = false;
        }

        // determing the player is on left or right, then chasing.

        bool next_direction = x > 0 ? true : false;

        if(next_direction != directionRight) {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        directionRight = next_direction;

        if(Math.Abs(x) < 0.05) return;

        if (directionRight)
        {   
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
    }

    public void Die() {
        isDead = true;
        anim.SetBool("isMove", false);
        anim.SetBool("isDead", true);
    }
}
