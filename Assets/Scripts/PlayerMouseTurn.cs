using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseTurn : MonoBehaviour {

   // public Rigidbody rb;
    bool isPaused = false;
	void Start () {
		
	}

	void LateUpdate(){


        if(Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;
            //Debug.Log(isPaused);
        }
        if(isPaused){
             Cursor.lockState = CursorLockMode.None;
        }else{
              Cursor.lockState = CursorLockMode.Locked;
        }
        if(!isPaused){
            float mouseInput = Input.GetAxis("Mouse X")*4;
            Vector3 lookhere = new Vector3(0, mouseInput, 0);
            //if (Input.GetMouseButton(1))
            transform.Rotate(lookhere);
        }


        
        




    }



	
}