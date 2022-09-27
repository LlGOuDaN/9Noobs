using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SendToGoogle : MonoBehaviour
{


[SerializeField] private string URL;
private long _sessionID;
private int _testInt;
private bool _testBool;
private float _testFloat=1000;




public static int dead_num;




public void Send(int scene_id = -1,bool pass = false, float time_duration = -1)
{
 // Assign variables

 _sessionID = DateTime.Now.Ticks;
 _testInt =scene_id;
 _testBool = pass;
 _testFloat = time_duration;


 StartCoroutine(Post(_sessionID.ToString(), _testInt.ToString(), 
_testBool.ToString(), _testFloat.ToString()));



}


void OnApplicationQuit(){

 

 Send();

}

private void Awake()
{
 // Assign sessionID to identify playtests


    //start_time = Time.time;

 

}

private IEnumerator Post(string sessionID, string testInt, string testBool, string
testFloat)
{
 // Create the form and enter responses
 WWWForm form = new WWWForm();
 form.AddField("entry.245026862", sessionID);
 form.AddField("entry.142189542", testInt);
 form.AddField("entry.187928650", testBool);
 form.AddField("entry.584057142", testFloat);
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
        
    }



    // Update is called once per frame
void Update()
    {
        
    }









}








