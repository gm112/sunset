using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMover : MonoBehaviour
{
    float rnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        rnd = Random.Range(.6f,1.2f);
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //170
       transform.Translate(transform.forward*170*Time.fixedDeltaTime*rnd,Space.World);
       Destroy (gameObject, 2.2f);
    }
}
