using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseTrigger : MonoBehaviour
{
    public GameObject collapseObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collapse collapse = (Collapse)collapseObject.GetComponent(typeof(Collapse));
        wait();
        collapse.isTriggered = true;
    }

    IEnumerator wait() {
        yield return new WaitForSecondsRealtime(0.5f);
    }

}
