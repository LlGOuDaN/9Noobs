using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoNew : MonoBehaviour
{
    private GameObject player_object;
    private SpriteRenderer renderer;
    private Vector3 scale;

    private float echoTime;

    private bool isKeyDown;
    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.FindWithTag("Player");
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.color = Color.clear;
        scale = renderer.transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (GameManager.disableInput)
        {
            return;
        }

        // record current time to evaluates we are switching or echoing
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Q)) {
           echoTime = Time.time;
           isKeyDown = true;
        } 

        // it's a long press, echo!
        if(isKeyDown && Time.time - echoTime > 0.3){
            renderer.color = player_object.GetComponent<SpriteRenderer>().color==Color.white ? Color.white: Color.black ;
            renderer.transform.localScale *=  (1+Time.deltaTime);
        }

        // echo finish and restore
        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.Q))
        {
            isKeyDown = false;
            Restore();
        }

        
        
    }

        void Restore() {
        renderer.transform.localScale = scale;
        renderer.color = renderer.color = Color.clear;
     }
}