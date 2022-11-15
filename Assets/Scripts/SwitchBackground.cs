using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchBackground : MonoBehaviour
{
    public GameObject darkLight;
    // Start is called before the first frame update
    void Start()
    {
        darkLight = GameObject.Find("Background");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRealWhite;
        if (Int32.Parse(SceneManager.GetActiveScene().name) < 3){
            isRealWhite = darkLight.GetComponent<DarkLightBlockController>().isWhite;
        }
        else{
            isRealWhite = ! darkLight.GetComponent<DarkLightBlockController>().isWhite;
        }

        if (isRealWhite)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
