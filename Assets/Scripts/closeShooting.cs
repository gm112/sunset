using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeShooting : MonoBehaviour
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



    private void OnTriggerStay(Collider other)
    {
         
            if(other.gameObject.tag == "enemy"){
                Debug.Log("ENEMYISCLOSE");
                  Debug.Log("yooo");
                    if(Input.GetMouseButton(0)){
                        other.gameObject.SendMessage("ApplyDamage",.2f);
                    }
                //Destroy (gameObject,.2f);
            }
 
    }

}
