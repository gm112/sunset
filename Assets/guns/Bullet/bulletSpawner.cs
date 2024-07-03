using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    bool isFiring = false;
    public GameObject bullet;

    public ParticleSystem bulletp;
    public ParticleSystem bulletclose;
    //ParticleSystem.Particle[] m_Part;

    public Transform bulletSpawn;

    public ParticleSystem muzzleFlash;


     float targetTime = 0f;
     public Animator anim;
     float MaxOffset = .01f;

        public AudioSource _audioSource;
        public AudioClip mclip;

        public AudioClip bulletbounce1;
        public AudioClip bulletbounce2;
        public AudioSource _bounceSource;
    
    public ParticleSystem shells;
 
    public bool canShoot=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            //Debug.Log("1");
            isFiring = true;
        }else{
            isFiring = false;
        }
        if(isFiring){
             //Debug.Log("2");
            anim.SetBool("isShooting",true);
             targetTime -= Time.deltaTime;



             if (targetTime <= 0.0f)
            {
                canShoot=true;
            }else{
                canShoot = false;
            }
            if(canShoot){
                //Debug.Log("BOOM");

                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation*Quaternion.Euler(Random.Range(-1,1),Random.Range(-1,1),0)); // this will instantiate the bullet as the same rotation set in your prefab 
              // bulletp.Emit(1);
              // bulletclose.Emit(1);
                shells.Emit(1);
                int pp = Random.Range(0,100);

                if(pp==2){
                    _bounceSource.pitch = Random.Range(.7f, 1.2f);
                    _bounceSource.PlayOneShot(bulletbounce2,1.5f);
                }
                 _audioSource.pitch = Random.Range(1f, 1f+MaxOffset);
                _audioSource.PlayOneShot(mclip,1f);


                targetTime = .1f;
            }
           
            
            if(!muzzleFlash.isPlaying)muzzleFlash.Play();
           // instantiated.transform.SetPositionAndRotation(weaponMuzzle.position , instantiated.transform.rotation); // if totation doesn't work here try quaternion.identity() function instead of instantiated.transform.rotation
        }else{
            if(muzzleFlash.isPlaying)muzzleFlash.Stop();
            anim.SetBool("isShooting",false);
        }
    }

    private void LateUpdate()
    {
       // InitializeIfNeeded();

        // GetParticles is allocation free because we reuse the m_Particles buffer between updates
      //  int numParticlesAlive = bulletp.GetParticles(m_Part);

        // Change only the particles that are alive
      //  for (int i = 0; i < numParticlesAlive; i++)
      //  {
      //      m_Part[i].simulationSpace = ParticleSystemSimulationSpace.World;
      //  }

        // Apply the particle changes to the Particle System
      //  bulletp.SetParticles(m_Part, numParticlesAlive);
    }

    void FixedUpdate(){

    }
}
