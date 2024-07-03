using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteDirection2 : MonoBehaviour
{
	public Transform target;
	float Ydiff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ydiff = target.transform.eulerAngles.y - transform.eulerAngles.y-180;
        if(Ydiff < 0){
        	Ydiff= Ydiff+360;
        }
    }

    void dd(){

    }

    //void OnGUI(){
    //	GUIStyle style = new GUIStyle();
    //    style.fontSize = 24;
    //    style.normal.textColor = Color.white;
    //	  GUI.Label(new Rect(10, 0, 0, 0), Ydiff.ToString() , style);
   //}
}
