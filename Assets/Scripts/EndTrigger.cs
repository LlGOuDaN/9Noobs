using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class EndTrigger : MonoBehaviour


{

    public static float end_x = 0;
    public static float end_y = 0;
    void Start()
    {
        end_x = transform.position[0]; //get x position of end point 
        end_y = transform.position[1]; //get y position of end point 

    }
    SendToGoogle STG;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameManager>().CompleteLevel();
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        int currentScene = Int32.Parse(SceneManager.GetActiveScene().name);
        if (collision.tag == "Player") {


            //for PM analytics
            STG = FindObjectOfType<SendToGoogle>();
            //float duration = Time.time - PlayerMovementController.t;
            
            STG.Send(currentScene, true, Time.time - PlayerMovementController.t,Time.time-PlayerMovementController.t_initial, 1.0F);//if player pass a certain level, send to google form;
            Debug.Log("Form Upload Complete!(For Passing)");

            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }
}
