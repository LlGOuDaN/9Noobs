using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAndFade : MonoBehaviour
{   
    private float rotZ;
    public float rotationSpeed;
    public float fallSpeed;
    public float fadeSpeed;
    public bool clockwiseRotation;
    public float angle;
    public bool isTriggered = false;

    public GameObject fadeObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    void Update()
    {
        if (isTriggered)
        {
            if (clockwiseRotation)
            {
                rotZ += Time.deltaTime * rotationSpeed;
            }
            else
            {
                rotZ += -Time.deltaTime * rotationSpeed;
            }
            transform.position+= Vector3.down * Time.deltaTime*fallSpeed;
            SpriteRenderer sp = fadeObject.GetComponent<SpriteRenderer>();
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - fadeSpeed * Time.deltaTime);
            if (Mathf.Abs(rotZ) < angle)
            {
                transform.rotation = Quaternion.Euler(0, 0, rotZ);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, rotZ * angle / Mathf.Abs(rotZ));
                isTriggered = false;
                gameObject.SetActive(false);
            }
        }

    }
}
