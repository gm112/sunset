using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public ParticleSystem psys;
    public float health = 1f;
    public Animator anim;
     Transform player;
     NavMeshAgent nAgent;
     float mspeed;

     float timeRemaining = 1f;
     float timeMod;
     public enemySightDetection sightDetect;

     float agro = 0f;
    // Start is called before the first frame update
    void Start()
    {
        mspeed = Random.Range(-1.1f, 3.1f);
        timeMod = Random.Range(-0.5f,0.5f);
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
		player = gos[0].transform;
        nAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nAgent.speed = 3.5f+mspeed;
           if(nAgent.enabled == true && agro > 0f){
                nAgent.destination = player.transform.position;
                timeRemaining = 1f+timeMod;
            }
    }

    // Update is called once per frame
    void Update()
    {
        if(nAgent.velocity.x == 0 && nAgent.velocity.z == 0 && health >0){
            anim.speed = 0;
        }else{
            anim.speed =1;
        }
        if(sightDetect.canSeePlayer){
            agro = 1f;
        }
        if(health <=0){
            anim.SetBool("IsDead",true);
            GetComponent<Collider>().enabled = false;
            nAgent.enabled = false ;
        }
        
       
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
         
        }
        if(timeRemaining <= 0){
            if(nAgent.enabled == true && agro > 0f){
                nAgent.destination = player.transform.position;
                timeRemaining = 1f+timeMod;
            }
        }
        
    }

    public void ApplyDamage(float damage){
        //print("appliedDamage?");
        health = health - damage;
       // Debug.Log("delt:" + damage.ToString());
        psys.Emit(20);
        psys.Stop();
    }
}
