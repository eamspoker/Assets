using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnCollider : MonoBehaviour
{
 private GameObject GameManager;
    private GameManagerScript manager;
    bool listening;
    float time;
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

        bool hasAll = manager.inventory.Contains("future_token");
        if(hasAll){
            manager.displayAlert("Entering Tree of Life");
            SceneManager.LoadScene("TheFuture");
        }
        else
        {
             manager.displayDialog("The key to the future is to plant a seed in the past.", "????", transform.position);

        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        manager.touchingObj = null;
    }
}
