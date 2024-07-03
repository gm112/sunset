using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpGunSprite : MonoBehaviour
{
    RectTransform m_Rect;
    float xPos;
    float pp;
    float curbobAmount = 4f;
    float timer = Mathf.PI / 2;
    
    float bobSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rect = GetComponent<RectTransform>();
        xPos = m_Rect.anchoredPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            timer += bobSpeed * Time.deltaTime;

            
            pp = Mathf.Abs((Mathf.Sin(timer) * curbobAmount*2f));
            
        }
        m_Rect.anchoredPosition = new Vector2(xPos+pp, m_Rect.anchoredPosition.y);

    }
}
