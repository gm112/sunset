using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] WallRun wallRun;

    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;

    [SerializeField] Transform cam = null;
    [SerializeField] Transform orientation = null;

    //public Transform camPosTarget;
    //public Transform camLerping;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;
    float mod;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
         
        //yRotation += mouseX * sensX * multiplier;
        yRotation = 0;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.rotation = Quaternion.Euler(xRotation, cam.transform.eulerAngles.y, wallRun.tilt);
        
        //cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, wallRun.tilt);
    
        //cam.transform.rotation = Quaternion.Euler(camPosTarget.eulerAngles.x,orientation.eulerAngles.y,camLerping.eulerAngles.z);
        
        //cam.transform.rotation = Quaternion.Euler(camPosTarget.eulerAngles.x,orientation.eulerAngles.y,wallRun.tilt);
    //     Quaternion filler = Quaternion.Euler(camPosTarget.eulerAngles.x,orientation.eulerAngles.y,wallRun.tilt);
    //    Quaternion modz = Quaternion.Slerp(filler,camLerping.rotation,0.4f);
    //    //Debug.Log(modz);
    //    cam.transform.rotation = Quaternion.Euler(camPosTarget.eulerAngles.x,orientation.eulerAngles.y,modz.eulerAngles.z);
    //     orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
