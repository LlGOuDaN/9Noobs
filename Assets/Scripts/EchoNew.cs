using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoNew : MonoBehaviour
{
    private GameObject player_object;
    private SpriteRenderer renderer;
    private Vector3 scale;
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
        if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.E))
        {
            renderer.color = player_object.GetComponent<SpriteRenderer>().color==Color.white ? Color.white: Color.black ;
            
            renderer.transform.localScale *=  (1+Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.E))
        {
            Restore();
        }
        
    }

        void Restore() {
        renderer.transform.localScale = scale;
        renderer.color = renderer.color = Color.clear;
     }
}