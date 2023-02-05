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
    public GameObject UIText;
    public GameObject UIButton;
    public GameObject textBubble;
    public GameObject textBubbleText;
    private int verticalOffset = 3;

    // Start is called before the first frame update
    void Start()
    {

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
}
