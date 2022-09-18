using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour
{
    private float rotZ;
    public float rotationSpeed;
    public bool clockwiseRotation;
    public float angle;
    public bool isTriggered = false;

    void Update() {
        if (isTriggered) {
            if (clockwiseRotation)
            {
                rotZ += Time.deltaTime * rotationSpeed;
            }
            else
            {
                rotZ += -Time.deltaTime * rotationSpeed;
            }
            if (Mathf.Abs(rotZ) < angle)
            {
                transform.rotation = Quaternion.Euler(0, 0, rotZ);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, rotZ * angle / Mathf.Abs(rotZ));
                isTriggered = false;
            }
        }
        
    }
}
