using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTilt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hmove = Input.GetAxisRaw("Horizontal");
        Quaternion LeftRotation = Quaternion.Euler(0, 0, 3f);
        Quaternion RightRotation = Quaternion.Euler(0,0,-3f);
        Quaternion zero = Quaternion.Euler(0,0,0);

        if(hmove<0){
            //Debug.Log("leeeeft");
            //transform.localRotation(0,0,1);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, LeftRotation,Time.deltaTime*4f);
        }
        if(hmove>0){
            transform.localRotation = Quaternion.Lerp(transform.localRotation, RightRotation,Time.deltaTime*4f);
        }
        if(hmove == 0){
            transform.localRotation = Quaternion.Lerp(transform.localRotation, zero,Time.deltaTime*4f);
        }

    }
}
