using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DarkLightBlockController : MonoBehaviour
{
    public bool isWhite;

    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.color = isWhite ? Color.white : Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.disableInput)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            isWhite = !isWhite;
            ChangeColor();
        }
        
    }

    void ChangeColor()
    {
        renderer.color = isWhite ? Color.white : Color.black;
    }
}
