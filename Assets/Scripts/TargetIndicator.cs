using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform Target;

    // Update is called once per frame
    void Update()
    {
        var dir=Target.position-transform.position;
        var angle=Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.AngleAxis(angle+90,Vector3.forward);
    }
}
