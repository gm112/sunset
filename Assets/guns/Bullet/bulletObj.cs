using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletObj : MonoBehaviour
{
    public float dmg = .2f;
    // Start is called before the first frame update
    void Awake()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y,transform.localPosition.z+Random.Range(-.1f,.7f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        

            //other.gameObject.SendMessage("ApplyDamage",dmg);
      
         
            if(other.gameObject.tag == "enemy"){
                  Debug.Log("yooo");
                other.gameObject.SendMessage("ApplyDamage",dmg);
                //Destroy (gameObject,.2f);
            }
         
        
    }
}
