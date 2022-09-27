using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColliderController : MonoBehaviour
{
    private Color obstacle_color;
    private Color player_color;
    private GameObject player_object;
    // Start is called before the first frame update
    void Start()
    {
        obstacle_color = gameObject.GetComponent<SpriteRenderer>().color;
        player_object = GameObject.FindWithTag("Player");
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
        PolygonCollider2D polygon = gameObject.GetComponent<PolygonCollider2D>(); 
        if( player_color != obstacle_color ) {
            polygon.enabled = false;
        }
        else{
            polygon.enabled = true;
        }
    }
}
