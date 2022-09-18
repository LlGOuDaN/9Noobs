using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorialEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // FindObjectOfType<GameManager>().CompleteLevel();
            if (CompareTag("HMoveTtrlEndPoint"))
            {
                MoveTutorialManager.instance.HMoveTtrlEndPoint.SetActive(false);
                MoveTutorialManager.instance.JumpTipMark.SetActive(true);
            }
            if (CompareTag("JumpTipMark"))
            {
                MoveTutorialManager.instance.JumpTipMark.SetActive(false);
                MoveTutorialManager.instance.JumpTtrlEndPoint.SetActive(true);
            }

            if (CompareTag("JumpTtrlEndPoint"))
            {
                MoveTutorialManager.instance.JumpTtrlEndPoint.SetActive(false);
                MoveTutorialManager.instance.EndPoint.SetActive(true);
            }

            MoveTutorialManager.instance.tutorialPhaseNum += 1;
            // Debug.Log(MoveTutorialManager.instance.tutorialPhase);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
