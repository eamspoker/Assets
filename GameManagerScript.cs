using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    public bool isTransitioning = false;
    public bool updatingPockets = false;
    public GameObject touchingObj;
    public ArrayList inventory = new ArrayList();
    public float UITextDisplayTime = 2.0f;
    public float UITextDisplayTimeRemaining = 0f;
    public float textBubbleDisplayTime = 2.0f;
    public float textBubbleDisplayTimeRemaining = 0f;
    public float alertDisplayTime = 2.0f;
    public float alertDisplayTimeRemaining = 0f;
    public GameObject UIText;
    public GameObject UIButton;
    public GameObject textBubble;
    public GameObject textBubbleText;
    public GameObject player;
    public GameObject alert;
    public GameObject alertText;
    private int verticalOffset = 3;
    // set to false to play beginning
    public bool hasStarted;
    public int narrationCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
        player.SetActive(false);
        UITextDisplayTime = 5.0f;
        textBubbleDisplayTime = 5.0f;
    
    }

    // Update is called once per frame
    void Update()
    {
            // itemTextDisplayTime
            if (UITextDisplayTimeRemaining > 0 && touchingObj == null)
            {
                UITextDisplayTimeRemaining -= Time.deltaTime;
            }

            if (UITextDisplayTimeRemaining < 0)
            {
                UITextDisplayTimeRemaining = 0;
            }

            if (UITextDisplayTimeRemaining == 0)
            {
                UIButton.SetActive(false);
                UIText.SetActive(false);
                UIText.GetComponent<TextMeshProUGUI>().SetText("");
            }

            // textBubbleDisplayTime
            if (textBubbleDisplayTimeRemaining > 0 && touchingObj == null)
            {
                textBubbleDisplayTimeRemaining -= Time.deltaTime;
            }

            if (textBubbleDisplayTimeRemaining < 0)
            {
                textBubbleDisplayTimeRemaining = 0;
            }

            if (textBubbleDisplayTimeRemaining == 0)
            {
                textBubble.SetActive(false);
                textBubbleText.GetComponent<TextMeshProUGUI>().text = "";
            }

            // textBubbleDisplayTime
            if (alertDisplayTimeRemaining > 0)
            {
                alertDisplayTimeRemaining -= Time.deltaTime;
            }

            if (alertDisplayTimeRemaining < 0)
            {
                alertDisplayTimeRemaining = 0;
            }

            if (alertDisplayTimeRemaining == 0)
            {
                alert.SetActive(false);
                alertText.GetComponent<TextMeshProUGUI>().text = "";
            }

            if(!hasStarted && narrationCount < 5 && UITextDisplayTimeRemaining == 0)
            {
                print(hasStarted);
                narration(narrationCount);
                narrationCount++;
            } else if(!hasStarted && narrationCount >= 5 && UITextDisplayTimeRemaining == 0)
            {
                isTransitioning = true;
                narration(narrationCount);
                hasStarted = true;
                UITextDisplayTime = 2.0f;
                textBubbleDisplayTime = 2.0f;
            }
        
    }

    public void narration(int i)
    {

        if(i == 0)
        {
            displayDialog("Long Ago…\nWhen Shroomanity was but a child in the cosmos…", "????", Vector3.zero);
        } else if(i==1)
        {
            displayDialog("Its future hung in the balance…\n", "????", Vector3.zero);
        } else if(i==2)
        {
            displayDialog("Always happy…\nThe Shroomans took as they pleased…\n", "????", Vector3.zero);
        } else if(i==3)
        {
            displayDialog("Such was the gift of the Tree of Life…\n", "????", Vector3.zero);
        } else if(i==4)
        {
            displayDialog("But no gift lasts forever…\n", "????", Vector3.zero);

        } else if(i == 5)
        {
            player.SetActive(true);
        }
    }

   

    public void displayDialog(string textBubbleContent, string UITextContent, Vector3 objPosition)
    {
        // UI TextMeshPro
        UIButton.SetActive(true);
        UIText.SetActive(true);
        UIText.GetComponent<TextMeshProUGUI>().SetText(UITextContent);
        UITextDisplayTimeRemaining = UITextDisplayTime;

        // Text Bubble
        
        textBubble.SetActive(true);
        textBubbleText.GetComponent<TextMeshProUGUI>().text = textBubbleContent;
        // offset
        // Vector3 touchingObjPos = objPosition;
        // touchingObjPos.y += verticalOffset;
        // textBubble.transform.position = touchingObjPos;
        textBubbleDisplayTimeRemaining = textBubbleDisplayTime;
    }

    public void displayAlert(string content)
    {
        // UI TextMeshPro
        alertText.GetComponent<TextMeshProUGUI>().text = content;
        alert.SetActive(true);
        alertDisplayTimeRemaining = alertDisplayTime;
        

    
    }
}
