using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DarkLightBlockController : MonoBehaviour
{
    public static bool isWhite;

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

        if(WorldSwitchController.isSwitch)
        {
            isWhite = !isWhite;
            ChangeColor();
        }
       //Debug.Log(isWhite);
        
    }

    void ChangeColor()
    {
        renderer.color = isWhite ? Color.white : Color.black;
    }
}
