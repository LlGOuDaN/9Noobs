using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float rotZ;
    public float rotationSpeed;
    public bool clockwiseRotation;

    void Update() {
        if (clockwiseRotation) {
            rotZ += Time.deltaTime * rotationSpeed;
        }
        else {
            rotZ += -Time.deltaTime * rotationSpeed;
        }
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
