using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDamage : MonoBehaviour
{

    
    List<GameObject> targets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void SendTheDamage(){
           foreach(GameObject target in targets){
                target.SendMessage("ApplyDamage",5f);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
         //Debug.Log("ENEMYISCLOSE");
        if (other.tag == "enemy")
        {
           
            targets.Add(other.gameObject);    // <--- Error
        }
 
    }
    private void OnTriggerExit(Collider other){
        if(other.tag == "enemy"){
            targets.Remove(other.gameObject);
        }
    }
}
