using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob2 : MonoBehaviour
{
    [Header("References")]
    public Vector3 restPosition;
    public Transform camera;
    
    [Header("Settings")]
    public float bobSpeed = 11f;
    public float bobAmount = 0.05f;
    float curbobAmount = 0.05f;
     bool isSprinting = true;
    private float timer = Mathf.PI / 2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            isSprinting = !isSprinting;
        }
        if(isSprinting){
            curbobAmount = bobAmount;
            bobSpeed = 14f;
        }else{
            curbobAmount = bobAmount/2f;
            bobSpeed = 11f;
        }
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            timer += bobSpeed * Time.deltaTime;

            Vector3 newPosition = new Vector3(Mathf.Cos(timer) * bobAmount,
                restPosition.y + Mathf.Abs((Mathf.Sin(timer) * curbobAmount*2f)), restPosition.z);
            camera.localPosition = newPosition;
        }
        else
        {
            timer = Mathf.PI / 2;
        }

        if (timer > Mathf.PI * 2)
        {
            timer = 0;    
        }
    }
}