using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class swordSwing2 : MonoBehaviour
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
 
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime>1f && anim.GetCurrentAnimatorStateInfo(0).IsName("swordIdle")){
               noOfClicks = 0;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            anim.SetBool("hit1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            anim.SetBool("hit2", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
            anim.SetBool("hit3", false);
            noOfClicks = 0;
        }
 
 
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
 
        //cooldown time
        if (Time.time > nextFireTime)
        {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
 
            }
        }
    }
 
    void OnClick()
    {
        //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            _audioSource.pitch = Random.Range(1f-MaxOffset, 1f+MaxOffset);
                _audioSource.PlayOneShot(mclip,1f);
            anim.SetBool("hit1", true);
            sendDamage.SendTheDamage();
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
 
        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            _audioSource.pitch = Random.Range(1f-MaxOffset, 1f+MaxOffset);
                _audioSource.PlayOneShot(mclip,1f);
                sendDamage.SendTheDamage();
            anim.SetBool("hit1", false);
            anim.SetBool("hit2", true);
        }
        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            _audioSource.pitch = Random.Range(1f-MaxOffset, 1f+MaxOffset);
                _audioSource.PlayOneShot(mclip,1f);
                sendDamage.SendTheDamage();
            anim.SetBool("hit2", false);
            anim.SetBool("hit3", true);
        }
    }


}