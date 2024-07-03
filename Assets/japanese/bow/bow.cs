using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{

    public Animator anim;
    public AudioSource _audioSource;
    public AudioClip fireClip;
    public AudioClip reloadClip;
    bool isPlaying = false;
    //Ray RayOrigin;
    RaycastHit hit;
    LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("enemy");
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetMouseButtonDown(0)  && anim.GetCurrentAnimatorStateInfo(0).IsName("bowIdle")){
               
               anim.Play("fireBow");
               _audioSource.pitch = 1f;
               _audioSource.PlayOneShot(fireClip,1f);
               isPlaying = false;
                print("wtf");
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit,100f,mask)){
                    if (hit.collider != null){
                        
                        if (hit.collider.tag =="enemy")
                        {
                            
                                hit.collider.gameObject.SendMessage("ApplyDamage",5f);

                        }
                    }
                    
                }
            }

            if(anim.GetCurrentAnimatorStateInfo(0).IsName("armBow")){
                
                
                if(isPlaying==false){
                    _audioSource.pitch = 1f;
                    _audioSource.PlayOneShot(reloadClip,1f);
                    isPlaying = true;

                }
            }
    }
}
