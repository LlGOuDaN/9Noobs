using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStepController : MonoBehaviour{

    
    public float speed;
    public int startPosition;
    public Transform[] points;

    private int currentPointIndex;

// Start is called before the first frame update
    void Start()
    {
        currentPointIndex = startPosition;
        transform.position = points[startPosition].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[currentPointIndex].position) < 0.2f)
        {
            currentPointIndex = (currentPointIndex+1) % points.Length;
        }

        transform.position =
            Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }
}
