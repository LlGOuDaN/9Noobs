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
        player_object = GameObject.Find("Player");
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.color = Color.clear;
        scale = renderer.transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            renderer.color = player_object.GetComponent<DarkLightBlockController>().isWhite ? Color.white: Color.black ;
            
            renderer.transform.localScale *=  (1+Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.Mouse1))
        {
            Restore();
        }
        
    }

        void Restore() {
        renderer.transform.localScale = scale;
        renderer.color = renderer.color = Color.clear;
     }
}