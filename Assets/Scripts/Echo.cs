using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    private SpriteRenderer renderer;
    private Color original_color;
    private GameObject player_object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            renderer = gameObject.GetComponent<SpriteRenderer>();
            renderer.color = Color.red;
            Invoke("Restore", 2f);
        }
        
    }
    void Restore() {
        player_object = GameObject.Find("Player");
        renderer.color = player_object.GetComponent<DarkLightBlockController>().isWhite ? Color.black : Color.white;
    }
}
