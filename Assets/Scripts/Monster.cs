using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : MonoBehaviour
{
    public float speed = 2;
    public double moveTime = 1;
    private Animator anim;
    private bool directionRight = false;
    private float timer;
    private bool isDead;


    // Start is called before the first frame update
    void Start()
    {   
        anim = GetComponent<Animator>();
        isDead = false;
        anim.SetBool("isMove", true);

        if(directionRight) {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
        if (directionRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if (timer > moveTime) 
        {
            directionRight = !directionRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            timer = 0;
        
        }
        
    }

    public void Die() {
        isDead = true;
        anim.SetBool("isMove", false);
        anim.SetBool("isDead", true);
    }
}
