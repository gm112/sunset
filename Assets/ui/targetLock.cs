using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetLock : MonoBehaviour
{
    public PlayerMovement pmover;
    public PhysicMaterial playerMat;
    public Image img;
    public LayerMask mask;
    public Rigidbody rb;
    public Transform player;
    public bool lunging = false;
    float distance;
    public Image indicatorImg;

    public int screenOffsetX;
    public int screenOffsetY;

       // float maxComboDelay = 1;
         public AudioSource _audioSource;
        public AudioClip mclip;
        public Animator anim;
       public SendDamage sendDamage;

    // Update is called once per frame
    void Update()
    {
        
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    
                    if (Physics.Raycast(ray, out hit,25f,mask)) {
                        Transform objectHit = hit.transform;

                        var tempColor = img.color;
                        tempColor.a = 0f;
                        img.color = tempColor;

                        distance = Vector3.Distance (player.position, hit.point);

                         var worldPos = hit.transform.position;
                        var screenPos = Camera.main.WorldToScreenPoint(worldPos);
                        screenPos.x += screenOffsetX;
                        // UITK (0,0) is (top,left), with Y+ down
                        screenPos.y = screenPos.y - screenOffsetY;
                    
                        screenPos.z = 0f;
                        indicatorImg.transform.position = screenPos;
                        indicatorImg.transform.Rotate(Vector3.forward *Time.deltaTime *100);

                        if(Input.GetMouseButtonDown(1)){
                            playerMat.staticFriction = 1f;
                            lunging = true;
                            rb.AddForce(Camera.main.transform.forward*hit.distance*200f,ForceMode.Acceleration);


                            anim.Play("hit1");
                            playAudio();
                            //send_damage();
                            StartCoroutine(send_damage());
                                 
                        }


                        
                    }else{
                        img.color = Color.white;
                        indicatorImg.transform.position = new Vector3(-3,-3,0);
                    }

                    Debug.Log(distance);
                    if(lunging && distance > 1f){
                         rb.AddForce(Camera.main.transform.forward*hit.distance*4f,ForceMode.Impulse);
                    }else{
                        lunging = false;
                        //Debug.Log("clooooose");
                    }
                    //continually add force toward hit point while lunging;
                    //if distance to hitpoint is low then lunging = false


    }

    void playAudio(){
        _audioSource.pitch = 1f;
                _audioSource.PlayOneShot(mclip,1f);
    }

    // void send_damage(){
        
    // }

    IEnumerator send_damage()
    {      
        yield return new WaitForSeconds(0.2f);
        sendDamage.SendTheDamage();
    }
}
