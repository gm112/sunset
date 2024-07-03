using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snipeScript : MonoBehaviour
{
    public GameObject snipeSprite;
    public GameObject scopeSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)){
            scopeSprite.SetActive(true);
            snipeSprite.SetActive(false);
        }else{
            scopeSprite.SetActive(false);
            snipeSprite.SetActive(true);
        }
    }
}
