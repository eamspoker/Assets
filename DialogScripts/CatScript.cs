using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
   private GameObject GameManager;
    private GameManagerScript manager;
    public GameObject cup;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        manager = GameManager.GetComponent<GameManagerScript>();
        cup.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {

        bool hasNip = manager.inventory.Contains("The Nip");
        manager.touchingObj = gameObject;
        if(hasNip)
        {
            manager.displayDialog("You da Shrooman! Take my special Nippy Cup.",
        "Fat Cat", transform.position);
        manager.inventory.Remove("The Nip");
        manager.displayAlert("Gave away The Nip");
        cup.SetActive(true);
        manager.updatingPockets = true;
        }
        else
        {
             manager.displayDialog("No Nip?", "Fat Cat", transform.position);

        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        manager.touchingObj = null;
    }
}
