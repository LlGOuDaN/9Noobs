using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    private SpriteRenderer renderer;
    private Color original_color;
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
            original_color = renderer.color;
            renderer.color = Color.red;
            Invoke("Restore", 2f);
        }
        
    }
    void Restore() {
        renderer.color = original_color;
    }
}
