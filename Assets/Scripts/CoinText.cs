using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text text;
    private Color color;
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();    }

    // Update is called once per frame
    void Update()
    {
        color = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().color;
        text.color = (color == Color.white) ? Color.black : Color.white;
        
    }
}
