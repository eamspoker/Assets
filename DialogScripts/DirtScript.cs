using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtScript : MonoBehaviour
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

        bool hasAll = manager.inventory.Contains("Cat Cup (Filled)") && 
            manager.inventory.Contains("Seed of Hope");
        manager.touchingObj = gameObject;
        if(hasAll)
        {
            manager.displayDialog("You have planted your Seed of Hope. It will take a long time to grow.",
        "????", transform.position);
         manager.displayAlert("Gave away all possessions");
        manager.inventory = new ArrayList();
        manager.inventory.Add("future_token");
        manager.updatingPockets = true;
        }
        else
        {
             manager.displayDialog("It’s a patch of dirt.", "Mycelio", transform.position);

        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        manager.touchingObj = null;
    }
}
