using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeScript : MonoBehaviour
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

        bool hasBerry = manager.inventory.Contains("Cat Cup");
        manager.touchingObj = gameObject;
        if(hasBerry)
        {
            manager.displayDialog("The water looks so fresh.",
        "Mycelio", transform.position);
        manager.inventory.Remove("Cat Cup");
        manager.inventory.Add("Cat Cup (Filled)");
        manager.displayAlert("Filled up cup");
        manager.updatingPockets = true;
        }
        else if(!manager.inventory.Contains("Cat Cup (Filled)"))
        {
             manager.displayDialog("The water looks so fresh. If only I had a cup …", "Mycelio", transform.position);

        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        manager.touchingObj = null;
    }
}
