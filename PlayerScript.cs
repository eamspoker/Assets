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
        lastVelocity = rb.velocity;

    }

  

    void OnCollisionEnter2D(Collision2D coll)
    {

        
        if(coll.collider == true)
        {
        if(coll.collider.gameObject.tag == "Door")
        {
            transform.position = PlayerSpawn.transform.position;
            manager.isTransitioning = true;
        }
        }
    }


    void Move()
    {
       Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);


       if (move.Equals(Vector3.zero))
       {
        // return to walking speed once not moving
        increasedSpeed = walkSpeed;

       } else {
        // increase speed while walking
        float potentialInc = increasedSpeed + 0.1f*Time.deltaTime;
        if (potentialInc > maxSpeed)
        {
            increasedSpeed = maxSpeed;
        } else {
            increasedSpeed = potentialInc;
        }
       }

       velocity = move * increasedSpeed;
       rb.velocity = velocity;
    }
}