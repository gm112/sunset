using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteDirectionW : MonoBehaviour
{

	//public Text txt;
	 Transform player;
	public SpriteRenderer spRen;
	public Animator anim;
	// public Sprite away;
	// public Sprite two;
	// public Sprite toward;
	// public Sprite four;

	// public Sprite right;

	// public Sprite six;
	// 	public Sprite left;
	// public Sprite eight;

	 float dir;
	float enemyAngle;

	float rotationSpd = 0f;

	void Start(){
		GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
		player = gos[0].transform;
	}
    // Update is called once per frame
    void Update()
    {
       
        float Ydiff = player.transform.eulerAngles.y - transform.eulerAngles.y-180;
        if(Ydiff < 0){
        	Ydiff= Ydiff+360;
        }
        enemyAngle = Ydiff;
    	    	//txt.text = enemyAngle.ToString();

    	chckAngle4();

    	//rotateToward();
		

    }



    void chckAngle4(){
    		//Debug.Log("yo");
    	    if (enemyAngle >= 310f || enemyAngle < 40f)
             dir = 1;
             if (enemyAngle >= 40f && enemyAngle < 67.5f)
             dir= 2;
            else if (enemyAngle >= 67.5f && enemyAngle < 112.5f)
             dir= 3;
             else if (enemyAngle >= 112.535f && enemyAngle < 157.5f)
             dir= 4;
             else if (enemyAngle >= 157.5f && enemyAngle < 202.5f)
             dir= 5; //
             else if (enemyAngle >= 202.5f && enemyAngle < 247.5f)
             dir= 6;  //
             else if (enemyAngle >= 247.5f && enemyAngle < 292.5f)
             dir= 7;   //
              else if (enemyAngle >= 292.5f && enemyAngle < 310f)
             dir= 8;   //

             assgnSprite();
    }


//			1
//		8		2
// 7                 3
//     6         4
//          5
//    

//       5
//    4       6
// 3             7
//    2       8
    void assgnSprite(){
    	if(dir ==1){
    		//spRen.flipX = false;
    		//spRen.sprite = away;
			anim.SetFloat("y",1f);
			anim.SetFloat("x",0f);

    	}
    	if(dir ==2){
    		spRen.flipX = true;
    		//spRen.sprite = two;
			anim.SetFloat("y",-1f);
			anim.SetFloat("x",1f);
    	}
    	if(dir == 3){
    		spRen.flipX = true;
    		//spRen.sprite = right;
			anim.SetFloat("y",0f);
			anim.SetFloat("x",1f);
    	}
    	if(dir == 4){
			//**
    		spRen.flipX = true;
    		//spRen.sprite = four;
			anim.SetFloat("y",1f);
			anim.SetFloat("x",1f);			
    	}
    	if(dir == 5){
    		spRen.flipX = false;
    		//spRen.sprite = toward;
			anim.SetFloat("y",-1f);
			anim.SetFloat("x",0f);	
    	}
    	//
    	if(dir == 6){
    		spRen.flipX = false;
    		//spRen.sprite = six;
			anim.SetFloat("y",1f);
			anim.SetFloat("x",-1f);	
    	}
    	if(dir == 7){
    		spRen.flipX = false;
    		//spRen.sprite = left;
			anim.SetFloat("y",0f);
			anim.SetFloat("x",-1f);	
    	}
    	if(dir == 8){
    		spRen.flipX = false;
    		//spRen.sprite = eight;
			anim.SetFloat("y",-1f);
			anim.SetFloat("x",-1f);	
    	}

    }




}
