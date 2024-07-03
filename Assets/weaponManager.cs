using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    float weaponState = 1;
    [Header("SMG")]
    public GameObject SMG_Manager;
    public GameObject gunCrossHair;
    public GameObject SMG_graphic;
    public GameObject SMG_ammo;
    [Header("sword")]
    public GameObject SwordGraphic;
    public GameObject swordCrossHair;
    [Header("beamRifle")]
    //public GameObject beamRifleGraphic;
    
    //public GameObject beamRifleManager;
    
    [Header("SniperRifle")]
    //public GameObject snipeHolder;
   // public GameObject snipeScopeGraphic;
   // public GameObject snipeGunGraphic;
    [Header("shrapCannon")]
    public GameObject shrapHolder;
    public GameObject shrapSprite;

    [Header("boomerang")]
    public GameObject boomHolder;
    public GameObject boomSprite;

    [Header("bow")]
    public GameObject bowSprite;

    bool isSet = true;

    
    // Start is called before the first frame update
    void Start()
    {
        setTofalse();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
              isSet = false;
            weaponState = 1f;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            weaponState = 2f;
            // weaponState = 6f;
              isSet = false;
           // weaponState = 7f; //bow
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
        //    weaponState = 3f;
        isSet = false;
        weaponState = 6f;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            isSet = false;
        //    weaponState = 4f;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            isSet = false;
            weaponState = 5f;
        }

        if(weaponState == 1f){
            if(isSet == false)setTofalse();
           
            SwordGraphic.SetActive(true);
            swordCrossHair.SetActive(true);
  

        }
        if(weaponState==2f){
            if(isSet == false)setTofalse();
            SMG_Manager.SetActive(true);
            SMG_graphic.SetActive(true);
            SMG_ammo.SetActive(true);

            gunCrossHair.SetActive(true);

        }
        if(weaponState==3f){
            if(isSet == false)setTofalse();
            //swordCrossHair.SetActive(true);
            //      beamRifleManager.SetActive(true);
            //beamRifleGraphic.SetActive(true);

        }

        if(weaponState==4f){
            if(isSet == false)setTofalse();
            //snipeGunGraphic.SetActive(true);
            //snipeHolder.SetActive(true);
           
        }

        if(weaponState==5f){
            if(isSet == false)setTofalse();
            gunCrossHair.SetActive(true);

            shrapHolder.SetActive(true);
            shrapSprite.SetActive(true);
        }

        if(weaponState==6f){
            if(isSet == false)setTofalse();
            boomHolder.SetActive(true);
            boomSprite.SetActive(true);

            
        }

        if(weaponState==7f){
            if(isSet == false)setTofalse();
            
            bowSprite.SetActive(true);
            swordCrossHair.SetActive(true);


        }


    }

    void setTofalse(){
        
            bowSprite.SetActive(false);
            swordCrossHair.SetActive(false);

            boomHolder.SetActive(false);
            boomSprite.SetActive(false);

            SwordGraphic.SetActive(false);
            SMG_Manager.SetActive(false);
            SMG_graphic.SetActive(false);
            SMG_ammo.SetActive(false);
            SwordGraphic.SetActive(false);
            gunCrossHair.SetActive(false);
            shrapHolder.SetActive(false);
            shrapSprite.SetActive(false);
           // beamRifleManager.SetActive(false);
           // beamRifleGraphic.SetActive(false);
           // snipeGunGraphic.SetActive(false);
           // snipeHolder.SetActive(false);
            isSet = true;
        

    }
}
