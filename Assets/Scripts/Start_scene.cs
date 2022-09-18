using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_scene : MonoBehaviour
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
        SceneManager.LoadScene("0");  
    }
}
