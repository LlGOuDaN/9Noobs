using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTransform : MonoBehaviour
{
    private Color square_color;
    private Color player_color;
    private GameObject player_object;
    // Start is called before the first frame update
    void Start()
    {
        square_color = gameObject.GetComponent<SpriteRenderer>().color;
        player_object = GameObject.Find("Player");
        ColliderDetect ();
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
            Invoke("ColliderDetect", 0.1f);
        }
        
    }

    void ColliderDetect (){
            player_color = player_object.GetComponent<SpriteRenderer>().color;
            BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>(); 
            if( player_color != square_color ) {
                box.enabled = false;
            }
            else{
                box.enabled = true;
            }
    }
}
