using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class EndTrigger : MonoBehaviour


{
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
            float duration = Time.time - PlayerMovementController.t;
            STG.Send(currentScene, true, duration);//if player pass a certain level, send to google form;
            Debug.Log("Form Upload Complete!(For Passing)");

            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }
}
