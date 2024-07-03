using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class swordSwing3 : MonoBehaviour
{
    public Animator anim;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
         public AudioSource _audioSource;
        public AudioClip mclip;

        float MaxOffset = .2f;
    float timerthing;

    public SendDamage sendDamage;
 
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
 
        if(Input.GetMouseButtonDown(0) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime>1f && anim.GetCurrentAnimatorStateInfo(0).IsName("swordIdle")){
               //noOfClicks = 0;
               anim.Play("hit1");
               playAudio();
                send_damage();
        }
        if (Input.GetMouseButtonDown(0) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
             send_damage();
            anim.Play("hit2");
            playAudio();
        }
        if (Input.GetMouseButtonDown(0) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
             send_damage();
            anim.Play("hit3");
            playAudio();
        }
        //if (Input.GetMouseButtonDown(0) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        //{
        //    anim.SetBool("hit3", false);
            
        //}
 
 
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            
        }
 

    }

    void playAudio(){
        _audioSource.pitch = Random.Range(1f-MaxOffset, 1f+MaxOffset);
                _audioSource.PlayOneShot(mclip,1f);
    }

    void send_damage(){
        sendDamage.SendTheDamage();
    }
 
   

    


}