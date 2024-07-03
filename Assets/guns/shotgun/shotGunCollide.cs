using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGunCollide : MonoBehaviour
{

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public float dmg = .2f;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        
        int i = 0;

        while (i < numCollisionEvents)
        {
            if(other.tag == "enemy"){
                other.SendMessage("ApplyDamage",dmg);
            }
            i++;
        }
    }

}
