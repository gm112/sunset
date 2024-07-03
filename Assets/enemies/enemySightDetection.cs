using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySightDetection : MonoBehaviour
{

    public bool canSeePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter( Collider other )
    {
        if ( other.tag == "Player" )
        {
            canSeePlayer = true;
        }
    }

    private void OnTriggerExit( Collider other )
    {
        if ( other.tag == "Player" )
        {
            canSeePlayer = false;
        }
    }
}
