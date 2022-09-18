using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorialManager : MonoBehaviour
{
    public static MoveTutorialManager instance = null;
    public int tutorialPhaseNum=0;

    public GameObject HMoveTtrlEndPoint;
    public GameObject MoveTutorial;
    public GameObject JumpTtrlEndPoint;
    public GameObject JumpTipMark;
    public GameObject EndPoint;


    private enum TutorialPhase
    {
        tutorialStart,
        showHMoveTip,
        waitPlayerHMove,
        waitPlayerToEdge,
        showJumpTip,
        waitPlayerJump,
        tutorialDone
    }

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
                //If instance already exists and it's not this:
        else if (instance != this)
        {    //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        tutorialPhaseNum = (int)TutorialPhase.tutorialStart;
        MoveTutorial = GameObject.Find("MoveTutorial");
        HMoveTtrlEndPoint = MoveTutorial.transform.Find("HMoveTtrlEndPoint").gameObject;
        JumpTtrlEndPoint = MoveTutorial.transform.Find("JumpTtrlEndPoint").gameObject;
        JumpTipMark = MoveTutorial.transform.Find("JumpTipMark").gameObject;
        EndPoint= MoveTutorial.transform.Find("EndPoint").gameObject;

    }

    private void ShowHMoveTipObjects()
    {
        HMoveTtrlEndPoint.SetActive(true);

    }

    public void HideHMoveTipObjects()
    {
        HMoveTtrlEndPoint.SetActive(false);
        
    }

    private void ShowJumpTipObjects()
    {
        JumpTipMark.SetActive(false);

    }

    private void HideJumpTipObjects()
    {


    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(tutorialPhaseNum);
        switch (tutorialPhaseNum)
        {
            case (int)TutorialPhase.tutorialStart:
                tutorialPhaseNum += 1;
                break;
            case (int)TutorialPhase.showHMoveTip:
                ShowHMoveTipObjects();
                tutorialPhaseNum += 1;
                break;
            case (int)TutorialPhase.waitPlayerHMove:
                break;
            case (int)TutorialPhase.waitPlayerToEdge:
                //HideHMoveTipObjects();
                break;
            case (int)TutorialPhase.showJumpTip:
                ShowJumpTipObjects();
                tutorialPhaseNum += 1;
                break;
            case (int)TutorialPhase.waitPlayerJump:
                break;
            case (int)TutorialPhase.tutorialDone:
                // HideJumpTipObjects();
                break;


        }
        
    }
}
