using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassDistortion : MonoBehaviour
{

    public Material grassMat;
    public Transform cam;
    Vector2 pp;
    public Renderer rend;
    public Rigidbody player;
   
    float y;
    float x;
    

    // Start is called before the first frame update
    void Start()
    {
        rend.sharedMaterial = grassMat;
    }

    // Update is called once per frame
    void Update()
    {
        //meshRenderer.sharedMaterial
        //Debug.Log(cam.eulerAngles.y);
        //Debug.Log((player.velocity * Vector3.Dot( player.velocity.normalized, transform.forward)).z);
        //float vel = (player.velocity * Vector3.Dot( player.velocity.normalized, transform.forward)).z;
       // Debug.Log(vel);
        
        float posy = cam.eulerAngles.x/360*(-10f)+y;
        
        pp = new Vector2(cam.eulerAngles.y/360f*10f+x,posy);
        grassMat.SetVector("_DistortionOffset",pp);
    }
    void FixedUpdate(){
        y = y+Input.GetAxisRaw("Vertical")/60f;
        x = x+Input.GetAxisRaw("Horizontal")/20f;
    }
}
