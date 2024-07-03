using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwScript : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            anim.SetBool("isThrown",true);
        }
        //  if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime>.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("throwThrow")){
        //        anim.SetBool("isThrown",false);
        // }
    }
}
