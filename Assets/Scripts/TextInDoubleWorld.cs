using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextInDoubleWorld : MonoBehaviour
{
    public TextMeshPro text;
    public GameObject darkLight;
    // Start is called before the first frame update
    void Start()
    {
        // color = gameObject.GameObject.Find("Background")

        text = gameObject.GetComponent<TextMeshPro>();
        darkLight = GameObject.Find("Background");
    }

    // Update is called once per frame
    void Update()
    {
        text.color = darkLight.GetComponent<DarkLightBlockController>().isWhite ? Color.black : Color.white;
    }
}
