using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer : MonoBehaviour
{
    public TextMeshPro text;
    public GameObject gameManager;
    public float timeTake;

    private Color color;

    // Start is called before the first frame update
    public void Start()
    {
        text = gameObject.GetComponent<TextMeshPro>();
        gameManager = GameObject.Find("GameManager");
        timeTake = 0;
    }
        public void Update()
    {
        color = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().color;
        
        if (GameManager.disableInput){
            return;
        }
        if (Int32.Parse(SceneManager.GetActiveScene().name) < 3){
            text.color = color;
        }
        else{
            text.color = color;
        }
        if (!gameManager.GetComponent<GameManager>().isEnd()){
            timeTake += Time.deltaTime;
            updateText();
        }
    }

    public void updateText()
    {
        float minutes = Mathf.FloorToInt(timeTake / 60);
        float seconds = Mathf.FloorToInt(timeTake % 60);
        text.text = string.Format("{0:0} : {1:00}",minutes,seconds);
    }
}