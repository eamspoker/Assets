using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JesusFishTextBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject GameManager;
    private GameManagerScript manager;


    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

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
