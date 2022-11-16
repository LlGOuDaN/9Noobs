using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTransform : MonoBehaviour
{
    private Color square_color;
    private Color player_color;
    private GameObject player_object;
    private GameObject echo;
    // Start is called before the first frame update
    void Start()
    {
        square_color = gameObject.GetComponent<SpriteRenderer>().color;
        player_object = GameObject.FindWithTag("Player");
        echo = GameObject.Find("glowCircle");

        ColliderDetect ();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchDisable ();
        if (GameManager.disableInput)
        {
            return;
        }
        

        if(WorldSwitchController.isSwitch){
            Invoke("ColliderDetect", 0.1f);
        }
        
    }

    void SwitchDisable (){
            player_color = player_object.GetComponent<SpriteRenderer>().color;
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
            bool isKeyDown = echo.GetComponent<EchoNew>().getKeyDown();

            if(box != null){
                // if it is a block
                if( player_color != square_color ) {
                    sr.maskInteraction  =  SpriteMaskInteraction.VisibleInsideMask;
                }
                else{
                    sr.maskInteraction = SpriteMaskInteraction.None;
                }
            }
            else{
                // if it is a obstacle
                PolygonCollider2D polygon = gameObject.GetComponent<PolygonCollider2D>(); 
                if( player_color != square_color ) {
                    sr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                }
                else{
                    sr.maskInteraction = SpriteMaskInteraction.None;
                }
            }

    }

    void ColliderDetect (){
            player_color = player_object.GetComponent<SpriteRenderer>().color;
            BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();


            if(box != null){
                // if it is a block
                if( player_color != square_color ) {
                    box.enabled = false;
                }
                else{
                    box.enabled = true;
                }
            }
            else{
                // if it is a obstacle
                PolygonCollider2D polygon = gameObject.GetComponent<PolygonCollider2D>(); 
                if( player_color != square_color ) {
                    polygon.enabled = false;
                }
                else{
                    polygon.enabled = true;
                }
            }
            
    }
}
