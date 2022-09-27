using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.Analytics;
using Random = UnityEngine.Random;

public class SendToGoogle : MonoBehaviour
{

[SerializeField] private string URL;
private string _sessionID;
private int _testInt;
private bool _testBool;
private float _testFloat=1000;
private float _testFloat2 = 1000;
public static int dead_num;
public static bool ID_generated = false;
public static string  playerID;


public void Send(int scene_id = -1,bool pass = false, float time_duration = -1,float time_duration_cumulative= -1)
{
 // Assign variables

 
 //PlayerID is generated in the start() function;
 _sessionID = playerID;
 _testInt =scene_id;
 _testBool = pass;
 _testFloat = time_duration;
 _testFloat2 = time_duration_cumulative;


 StartCoroutine(Post(_sessionID.ToString(), _testInt.ToString(), 
_testBool.ToString(), _testFloat.ToString(),_testFloat2.ToString()));

}


private IEnumerator Post(string sessionID, string testInt, string testBool, string
testFloat,string testFloat2)
{
 // Create the form and enter responses
 WWWForm form = new WWWForm();
 form.AddField("entry.245026862", sessionID);
 form.AddField("entry.142189542", testInt);
 form.AddField("entry.187928650", testBool);
 form.AddField("entry.584057142", testFloat);
 form.AddField("entry.462510413", testFloat2);
 // Send responses and verify result
 using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
 {
 yield return www.SendWebRequest();
 if (www.result != UnityWebRequest.Result.Success)
 {
 Debug.Log(www.error);
 }
 else
 {
 Debug.Log("Form upload complete(For Player Death)!");
 }
 }
}


// Start is called before the first frame update
void Start()
    {  
        if (!ID_generated){//ID is only generated once
        playerID =  System.Guid.NewGuid().ToString();
        ID_generated = true;
        }


    }
       

// Update is called once per frame
void Update()
    {  
    }

void OnApplicationQuit()
{
 Send();
}

private void Awake()
{
}


}








