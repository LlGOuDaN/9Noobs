using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepColorChange : MonoBehaviour
{

    [SerializeField] float timeDuration = 3;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeColor", timeDuration);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<SpriteRenderer>().color != gameObject.GetComponent<SpriteRenderer>().color)
        {
            Debug.Log("false");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void ChangeColor()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr.color == Color.black)
        {
            sr.color = Color.white;
        }
        else
        {
            sr.color = Color.black;
        }
        Invoke("ChangeColor", timeDuration);
    }
}
