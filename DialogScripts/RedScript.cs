using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedScript : MonoBehaviour
{
   private GameObject GameManager;
    private GameManagerScript manager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        manager = GameManager.GetComponent<GameManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        manager.touchingObj = gameObject;
        manager.displayDialog(" My berries are the most delicious in all of Stumpton.",
        "Berry Farmer", transform.position);
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        manager.touchingObj = null;
    }
}
