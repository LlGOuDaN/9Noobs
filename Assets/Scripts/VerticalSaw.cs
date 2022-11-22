using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSaw : MonoBehaviour
{
    public float speed = 2;
    public double moveTime = 1;

    private bool directionRight = true;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (directionRight)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if (timer > moveTime)
        {
            directionRight = !directionRight;
            timer = 0;

        }

    }
}
