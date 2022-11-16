using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{

    private Transform cameraTransform;
    private Vector3 lastCamPosition;
    public float parallelEffectX;
    public float parallelEffectY;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCamPosition = cameraTransform.position;

    }

    void LateUpdate()
    {
        float delta_x = cameraTransform.position.x - lastCamPosition.x;
        float delta_y = cameraTransform.position.y - lastCamPosition.y;
        delta_x *= parallelEffectX;
        delta_y *= parallelEffectY;
        transform.position = new Vector3(transform.position.x - delta_x,transform.position.y - delta_y, transform.position.z);
        lastCamPosition = cameraTransform.position;
    }
}
