using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAndFadeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject fallObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FallAndFade fall = (FallAndFade)fallObject.GetComponent(typeof(FallAndFade));
        StartCoroutine(wait(fall));
        
        // fall.isTriggered = true;
    }

    IEnumerator wait(FallAndFade fallObject)
    {
        yield return new WaitForSecondsRealtime(0.4f);
        fallObject.isTriggered = true;

    }
}
