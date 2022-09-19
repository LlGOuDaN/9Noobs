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
        Button btn = transform.GetComponent<Button>();
        btn.onClick.AddListener(evenListener);
    }

    // Update is called once per frame
    void Update(){}


    // switch to another scene
    void evenListener() 
    {   
        int currentScene = Int32.Parse(SceneManager.GetActiveScene().name);
        Debug.Log(currentScene);
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
