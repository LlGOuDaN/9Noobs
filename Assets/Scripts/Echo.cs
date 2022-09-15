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
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            renderer = gameObject.GetComponent<SpriteRenderer>();
            renderer.color = Color.red;
            GameManager.disableInput = true;
            // Invoke("Restore", 2f);
        }

        if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.Mouse1))
        {
            Restore();
        }
        
    }
    void Restore() {
        player_object = GameObject.Find("Player");
        renderer.color = player_object.GetComponent<DarkLightBlockController>().isWhite ? Color.black : Color.white;
        GameManager.disableInput = false;
    }
}
