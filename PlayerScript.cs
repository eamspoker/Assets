using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float walkSpeed;
    public float maxSpeed;
    public float increasedSpeed;
    private Rigidbody2D rb;
    private Vector3 lastVelocity = Vector3.zero;
    public GameObject PlayerSpawn;
    public GameObject GameManager;
    private GameManagerScript manager;
    private Vector3 velocity;
    private enum Direction {front, back, left, right};
    private Direction orientation = Direction.front;
    private Animator anim;
    public GameObject triggerObj;


    #region basic functions
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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

    #endregion

    #region collisions
  void OnTriggerEnter2D(Collider2D coll)
    {
        triggerObj = coll.gameObject;
        
        if(coll.gameObject.tag == "CanGrab")
        {
            coll.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        triggerObj = null;
        if(coll.gameObject.tag == "CanGrab")
        {
            coll.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // if (coll.collider == true)
        // {

        //     // Debug.Log("Touching game object: " + coll.gameObject.name);
        //     manager.touchingObj = coll.gameObject;
        // }
    }

    private bool findDialog(string name)
    {

        return false;
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider == true)
        {
            manager.touchingObj = null;
            
        }
    }

    #endregion

    #region movement

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("up")) ||
            Event.current.Equals(Event.KeyboardEvent("w")))
        {
            anim.Play("Walking_Back");
            orientation = Direction.back;

        } else if(Event.current.Equals(Event.KeyboardEvent("down")) ||
            Event.current.Equals(Event.KeyboardEvent("s")))
        {
            anim.Play("Walking_Front");
            orientation = Direction.front;
        } else if(Event.current.Equals(Event.KeyboardEvent("right")) ||
            Event.current.Equals(Event.KeyboardEvent("d")))
        {
            anim.Play("Walking_Right");
            orientation = Direction.right;
        } else if(Event.current.Equals(Event.KeyboardEvent("left")) ||
            Event.current.Equals(Event.KeyboardEvent("a"))) {
            anim.Play("Walking_Left");
            orientation = Direction.left;
        }

        if(rb.velocity == Vector2.zero)
        {
            if(orientation == Direction.left) anim.Play("Left_Idle");
            else if(orientation == Direction.right) anim.Play("Right_Idle");
            else if(orientation == Direction.front) anim.Play("Idle_Front");
            else if(orientation == Direction.back) anim.Play("Back_Idle");
        }
    }

    void Move()
    {
        Vector3 move;

      
        if(orientation == Direction.left || orientation == Direction.right)
        {
            move =  new Vector3(Input.GetAxis("Horizontal"),0,0);
        } else {
            move =  new Vector3(0, Input.GetAxis("Vertical"),0);
        
        }

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

    #endregion

    #region item interaction
    void ItemInteraction()
    {
        // TODO: check whether the touching object is allowed to be interacted with
        if (Input.GetKey("x") && triggerObj != null)
        {
            Debug.Log("Interacting with the item: " + triggerObj.name);

            if(triggerObj.tag == "CanGrab")
            {
                manager.displayAlert("Obtained " + triggerObj.name);
                AddItemToInventory(triggerObj);
                Destroy(triggerObj);
                // tell pockets to update
                manager.updatingPockets = true;
            }
        }
    }

    void AddItemToInventory(GameObject obj)
    {
        manager.inventory.Add(obj.name);
        PrintGameManagerStatus();
    }
    #endregion

    #region display game manager status
    void PrintGameManagerStatus()
    {
        Debug.Log("Inventory:");
        foreach (string kvp in manager.inventory)
        {
            Debug.Log(string.Format("Item: {0}", kvp));
        }
        Debug.Log("touchingObj: " + manager.touchingObj);
        Debug.Log("UITextDisplayTimeRemaining: " + manager.UITextDisplayTimeRemaining);
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

