using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomerang : MonoBehaviour
{

    public Transform target;
    public Transform ChainTarget;
    //public LineRenderer LRen;

    bool didHit = false;
    bool didReturn = true;
    Vector3 hitPos;
    float startTime;
    public Animator anim;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        if(!didHit && didReturn){
            target.position = transform.position;
            anim.SetBool("isThrown",false);
            cube.SetActive(false);
          //  LRen.enabled = false;
        }else{
            cube.SetActive(true);
           // LRen.enabled = true;
        }
      // LRen.SetPosition(0,ChainTarget.position);
        //LRen.SetPosition(1,target.position);
       
        
        RaycastHit hit;
        if(Input.GetMouseButtonDown(1)&& didReturn){
            target.position = transform.position;
            startTime = Time.time;
            
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 28.0f)){
                didReturn = false;
               didHit = true;
                hitPos = hit.point;
                
                
            }
        }
        if(didHit){
            float journeyLength = Vector3.Distance(target.position, hitPos);
            float distCovered = (Time.time - startTime) * .5f;
            float fractionOfJourney = distCovered / journeyLength;
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime>.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("throwThrow")){
                 target.position = Vector3.Lerp(target.position, hitPos,fractionOfJourney);
            }
                  
        }
        if(target.position == hitPos){
            didHit = false;
            
        }
        if(!didReturn && !didHit){
            float journeyLength = Vector3.Distance(target.position, transform.position);
            float distCovered = (Time.time - startTime) * .1f;
            float fractionOfJourney = distCovered / journeyLength;
            target.position = Vector3.Slerp(target.position,transform.position,fractionOfJourney);
            if(fractionOfJourney >= .02f){
                anim.SetBool("isThrown",false);
            }
            //Debug.Log(fractionOfJourney);
            if(target.position == transform.position){
                didReturn = true;
            }
        }
    }

    void FixedUpdate(){
         
    }
}
