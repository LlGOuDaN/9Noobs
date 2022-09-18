using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLightMaskAnimation : MonoBehaviour
{       
    public float shrinkDuration = 1f;
    public GameObject mask;
    public Vector3 TargetScale = new Vector3(14, 7, 1);
    Vector3 startScale;
    float t = 0;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {   
        GameManager.disableInput = true;
        startScale = transform.localScale;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        if(t < 1) {
            t += Time.deltaTime / shrinkDuration;
            Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t);
            transform.localScale = newScale;
        }
        else {
            GameManager.disableInput = false;
            enabled = false;
        }
    }
}
