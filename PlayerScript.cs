using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float maxSpeed = 15.0f;
    public float increasedSpeed = 3.0f;
    private Rigidbody2D rb;
    private Vector3 lastVelocity = Vector3.zero;
    public GameObject PlayerSpawn;
    public GameObject GameManager;
    private GameManagerScript manager;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        manager = GameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ItemInteraction();
        ShowGameManagerStatus();
        lastVelocity = rb.velocity;

    }

  

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider == true)
        {
            Debug.Log("Touching game object: " + coll.gameObject.name);
            manager.touchingObj = coll.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider == true)
        {
            manager.touchingObj = null;
        }
    }


    void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);


        if (move.Equals(Vector3.zero))
        {
            // return to walking speed once not moving
            increasedSpeed = walkSpeed;

        }
        else
        {
            // increase speed while walking
            float potentialInc = increasedSpeed + 0.01f * Time.deltaTime;
            if (potentialInc > maxSpeed)
            {
                increasedSpeed = maxSpeed;
            }
            else
            {
                increasedSpeed = potentialInc;
            }
        }

       velocity = move * increasedSpeed;
       rb.velocity = velocity;
    }

    #region item interaction
    void ItemInteraction()
    {
        // TODO: check whether the touching object is allowed to be interacted with
        if (Input.GetKey("e") && manager.touchingObj != null)
        {
            Debug.Log("Interacting with the item: " + manager.touchingObj.name);
            AddItemToInventory(manager.touchingObj);
            Destroy(manager.touchingObj);
            manager.touchingObj = null;
        }
    }

    void AddItemToInventory(GameObject obj)
    {
        if (!manager.inventory.ContainsKey(obj.name))
        {
            manager.inventory[obj.name] = 0;
        }
        manager.inventory[obj.name]++;
        PrintGameManagerStatus();
    }
    #endregion

    #region display game manager status
    void PrintGameManagerStatus()
    {
        Debug.Log("Inventory:");
        foreach (KeyValuePair<string, int> kvp in manager.inventory)
        {
            Debug.Log(string.Format("Item: {0}, Count: {1}", kvp.Key, kvp.Value));
        }
    }

    void ShowGameManagerStatus()
    {
        if (Input.GetKeyDown("i"))
        {
            PrintGameManagerStatus();
        }
    }
    #endregion
}

