using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelButtonController : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("button initialized");
        Button btn = transform.GetComponent<Button>();
        btn.onClick.AddListener(eventListener);
        Debug.Log("eventListener added");
    }

    // Update is called once per frame
    void Update(){}


    // switch to another scene
    void eventListener() 
    {   
        int currentScene = Int32.Parse(SceneManager.GetActiveScene().name);
        Debug.Log("Next level button clicked: current scene " + currentScene);
        if (currentScene == GameManager.lastLevel) {
            Debug.Log("Loading first scene");
            SceneManager.LoadScene("0");  
        }
        else {
            Debug.Log("Loading next scene");
            SceneManager.LoadScene((currentScene + 1)+"");
        }
        GameManager.disableInput = false;
    }
}
