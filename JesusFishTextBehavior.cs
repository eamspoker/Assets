using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JesusFishTextBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject GameManager;
    private GameManagerScript manager;
    private int verticalOffset = 3;
    public string UITextContent = "Hello! I'm Jesus Fish.";
    public string textBubbleContent = "Jesus Fish";
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            // UI TextMeshPro
            manager.UIText.SetActive(true);
            manager.UIText.GetComponent<TextMeshProUGUI>().SetText(UITextContent);
            manager.UITextDisplayTimeRemaining = manager.UITextDisplayTime;

            // Text Bubble
            manager.textBubble.SetActive(true);
            manager.textBubbleText.GetComponent<TextMeshPro>().SetText(textBubbleContent);
            // offset
            Vector3 touchingObjPos = manager.touchingObj.transform.position;
            touchingObjPos.y += verticalOffset;
            manager.textBubble.transform.position = touchingObjPos;
            manager.textBubbleDisplayTimeRemaining = manager.textBubbleDisplayTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // UI TextMeshPro
        manager.UITextDisplayTimeRemaining = manager.UITextDisplayTime;

        // Text Bubble
        manager.textBubbleDisplayTimeRemaining = manager.textBubbleDisplayTime;
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject == player)
    //    {
    //        //itemText.SetActive(false);
    //    }
    //}
}
