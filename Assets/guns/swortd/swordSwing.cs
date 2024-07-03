using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class swordSwing : MonoBehaviour
{
    public Animator anim;
    public float targetTime = .8f;
    public bool slash = false;

    
        public AudioSource _audioSource;
        public AudioClip mclip;

        float MaxOffset = .2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetTime<=0){
           // Debug.Log("ZERO");
            anim.ResetTrigger("slash2");
        }
        if(Input.GetMouseButtonDown(0)&&targetTime>=.8f){
           // Debug.Log("YO");
            anim.SetTrigger("SlashTrigger");
            slash = true;
          _audioSource.pitch = Random.Range(1f-MaxOffset, 1f+MaxOffset);
                _audioSource.PlayOneShot(mclip,1f);
            
        }
        if(slash){
            targetTime -= Time.deltaTime;
            if(Input.GetMouseButtonDown(0)&&targetTime<.2f){
                anim.SetTrigger("slash2");
                anim.SetBool("Slash",true);
                
            }

        }else{
            targetTime = .8f;
        }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("SlashLeft1")&&targetTime<=0)
        {
            targetTime = .8f;
            slash = false;
            //anim.SetBool("Slash",false);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("SlashLeft1")){
            if(Input.GetMouseButtonDown(0)){
                anim.SetTrigger("slash2");
                anim.SetBool("Slash",true);
                 _audioSource.pitch = Random.Range(1f-MaxOffset, 1f+MaxOffset);
                _audioSource.PlayOneShot(mclip,1f);
            }
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("swipe3")){
            anim.SetBool("Slash",false);
             
        }
    }
}
