using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compass : MonoBehaviour
{

    public RawImage compassImage;
    public Transform player;

    //public List<QuestMarker> questMarkers = new List<QuestMarker>();
    float compassUnit;
    //public List<GameObject> questLocations = new List<GameObject>();
    public GameObject QuestLocation;
    public Image marker;

    // Start is called before the first frame update
    void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width/360f;
    }

    // Update is called once per frame
    void Update()
    {
       compassImage.uvRect = new Rect(player.localEulerAngles.y/ 360f,0f,1f,1f);
       marker.rectTransform.anchoredPosition = GetPosOnCompass();
    }

    Vector2 GetPosOnCompass(){
        Vector2 playerPos = new Vector2(player.transform.position.x,player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x,player.transform.forward.z);
        Vector2 questPos = new Vector2(QuestLocation.transform.position.x,QuestLocation.transform.position.z);

        float angle = Vector2.SignedAngle(questPos - playerPos, playerFwd);
        float modUnit = compassImage.rectTransform.rect.width/360f;
        //have marker follow above obj
        //return new Vector2(compassUnit * angle*(360f/70f),0f);
        return new Vector2(compassUnit * angle,-2f);
    
    }


}
