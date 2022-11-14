using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Class to handle world switch operation

Instruction:
    1. Create an empty object WorldSwitchController.
    2. Attach the WorldSwitchController script on it.
    3. Use isSwitch to trigger switch event.

Example:
    if(WorldSwitchController.isSwitch)
    {
        // ToDo
        // anything you want to change when world switching
    }

*/
public class WorldSwitchController : MonoBehaviour
{
    public static bool isSwitch;
    private float downTime;
    void Start()
    {
       isSwitch = false; 
    }

    // Update is called once per frame
    void Update()
    {   
        // evalute if it is a short press, if so, switching!
        isSwitch = false; 
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Q))
        {
            downTime = Time.time;
        }
       if ((Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.Q)) && Time.time - downTime < 0.3)
        { 
            Debug.Log( Time.time - downTime);
            isSwitch = true;
        }
        
    }
}
