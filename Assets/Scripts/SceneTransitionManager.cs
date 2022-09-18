using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int currentScene = Int32.Parse(SceneManager.GetActiveScene().name);
        if (collision.tag == "Player")
        {
            Debug.Log(currentScene);
            if (currentScene == GameManager.lastLevel)
            {
                FindObjectOfType<GameManager>().CompleteLevel();
                return;
            }
            SceneManager.LoadScene((currentScene + 1)+"");
        }
    }
}