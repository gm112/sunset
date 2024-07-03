using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wolfFindTarget : MonoBehaviour
{
    bool hasTargeted = false;
    Transform target;
    public NavMeshAgent nAgent;
    public GameObject wolfMain;
    public Transform wolfSpawnPoint;
    List<GameObject> targets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        target = wolfSpawnPoint;
       // List<GameObject> targets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {       
        

        
        if(target != null){
             nAgent.destination = target.position;
            rotateToward();

            
        }
        if(targets != null){
                if(targets.Count> 0){
                    target = targets[0].transform;
                }else{
                    target = wolfSpawnPoint;
                }

                for(int i =0;i<targets.Count;i++)
                {
                    if(targets[i].GetComponent<enemy>().health <=0)
                    {
                        targets.RemoveAt(i);
                        i--;
                    }
                }



        }else{
            target = wolfSpawnPoint;
        }
 


       

       

    }

    private void OnTriggerEnter(Collider other)
            {
                
                   
         
                    if ( other.tag == "enemy"){
                        
                        //add to list if enemy has life, if enemy has no life remove from list
                        //if list is empty then wolfSpawnPoint
       //                 if(other.GetComponent<enemy>().health > 0f){
                            targets.Add(other.gameObject);
       //                 }

                        
                        
                        
/*                         if(target == wolfSpawnPoint){

                            
                            target = other.gameObject.transform;
                        }else if(target.GetComponent<enemy>().health <= 0){
                            target = other.gameObject.transform;
                        } */
 
                        
                    }
                    
                
            }

    void rotateToward(){
    	Vector3 targetDirection = (target.position - transform.position).normalized;
		  var targetRotation = Quaternion.LookRotation(targetDirection);
		  transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation , Time.deltaTime * 3000f * 2);
    }
}
