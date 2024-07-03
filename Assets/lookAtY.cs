using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtY : MonoBehaviour
{

	public Transform target;



    // Update is called once per frame
    //void Update()
    //{

    	

     //      Vector3 targetPostition = new Vector3( target.position.x, 
                                      //  this.transform.position.y, 
                                      //  target.position.z ) ;
 	//		this.transform.LookAt( targetPostition ) ;
    //}

    void Update(){
    		float xx;
    	    transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
            float yy = transform.eulerAngles.y;
             
            //if(Camera.main.transform.rotation.eulerAngles.x<0.5f || Camera.main.transform.rotation.eulerAngles.x>340f){xx=0;}
            //else xx = Mathf.Clamp(transform.eulerAngles.x,0,22);
            

            //transform.rotation = Quaternion.Euler(xx, yy, 0);
            transform.rotation = Quaternion.Euler(0, yy, 0);

            //Debug.Log(Camera.main.transform.rotation.eulerAngles.x);
    }
}
