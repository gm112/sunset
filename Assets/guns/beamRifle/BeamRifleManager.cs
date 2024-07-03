using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamRifleManager : MonoBehaviour
{
    public Transform LaserOrigin;
    public LineRenderer LRen;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            LRen.enabled = true;
            LRen.SetPosition(0,LaserOrigin.position);
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100.0f)){
                LRen.SetPosition(1,hit.point);
                particle.SetActive(true);
                particle.transform.position = Vector3.MoveTowards(hit.point,LaserOrigin.position,.25f);
            }else{
                 LRen.enabled = false;
            particle.SetActive(false);
            }
        }else{
            LRen.enabled = false;
            particle.SetActive(false);
        }
    }
}
