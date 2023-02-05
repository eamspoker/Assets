using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooperBoy : MonoBehaviour
{
    private GameObject GameManager;
    private GameManagerScript manager;
    public GameObject seed;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        manager = GameManager.GetComponent<GameManagerScript>();
        seed.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {

        bool hasBerry = manager.inventory.Contains("Royal Blackberry");
        manager.touchingObj = gameObject;
        if(hasBerry)
        {
            manager.displayDialog("Delicious!",
        "Pooper Boy", transform.position);
        seed.SetActive(true);
        }
        else
        {
             manager.displayDialog("So hungry...", "Pooper Boy", transform.position);

        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        manager.touchingObj = null;
    }
}
