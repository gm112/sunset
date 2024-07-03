using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYSlowly : MonoBehaviour
{
    float speed = 22f;
    float height = .1f;
    float bobSpeed = 3f;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
       pos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
            


        transform.Rotate(Vector3.forward* Time.deltaTime * speed * 2f);

        float newY = Mathf.Sin(Time.time * bobSpeed)*height;
        //set the object's Y to the new calculated Y
       transform.localPosition = new Vector3(pos.x, pos.y+newY, pos.z);

    }
}
