using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrapTrigger : MonoBehaviour
{

    private GameObject blackStepTrap;
    private GameObject pressK;
    // Start is called before the first frame update
    void Start()
    {
        blackStepTrap = GameObject.Find("BlackStepTrap");
        pressK = GameObject.Find("Press_K");
        blackStepTrap.SetActive(false);
        pressK.SetActive(false);
    }

    void DisplayText()
    {
        pressK.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Trigger enter.");
        blackStepTrap.SetActive(true);
        for(int i = 0; i < blackStepTrap.transform.childCount; ++i){
            blackStepTrap.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
        }
        Invoke("DisplayText", 2.0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("Trigger exit.");
        blackStepTrap.SetActive(false);
    }
}
