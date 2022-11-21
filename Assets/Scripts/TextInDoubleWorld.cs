using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextInDoubleWorld : MonoBehaviour
{
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        // color = gameObject.GameObject.Find("Background")

        text = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = !DarkLightBlockController.isWhite ? Color.black : Color.white;
    }
}
