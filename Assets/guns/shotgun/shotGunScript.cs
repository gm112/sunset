using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGunScript : MonoBehaviour
{

    public ParticleSystem shotgun;
    public ParticleSystem grenade;
    public ParticleSystem smoke;
    public ParticleSystem flash;

    public AudioSource _audioSource;
    public AudioClip fireClip;
    public AudioClip grenadeClip;
    // Start is called before the first frame update
    void Start()
    {
        shotgun.Stop();
        grenade.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            shotgun.Play();
            smoke.Emit(10);
            flash.Emit(1);
            _audioSource.PlayOneShot(fireClip,1f);
        }else{
            shotgun.Stop();
        }
        if(Input.GetMouseButtonDown(1)){
            grenade.Play();
            smoke.Emit(10);
            flash.Emit(1);
            _audioSource.PlayOneShot(grenadeClip,1f);
        }else{
            grenade.Stop();
        }
    }

    
}
