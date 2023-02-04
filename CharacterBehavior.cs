using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public GameObject character;
    private GameObject touchObj;
    public float speed;
    private bool touch;

    // Start is called before the first frame update
    void Start()
    {
        touch = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = character.transform.position;
        if (Input.GetKey("w"))
        {
            pos += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

        // pick up the item and destroy the item
        if (Input.GetKey("e")&&touch)
        {
            Debug.Log("Collected the item:" + touchObj.name);
            Destroy(touchObj);
            touch = false;
            touchObj = null;
        }

        character.transform.position = pos;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter:" + collision.gameObject.name + ", " + Time.time);
        touch = true;
        touchObj = collision.gameObject;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Stay:" + collision.gameObject.name + ", " + Time.time);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit:" + collision.gameObject.name + ", " + Time.time);
        touch = false;
        touchObj = null;
    }

}
