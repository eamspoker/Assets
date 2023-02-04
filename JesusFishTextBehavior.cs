using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesusFishTextBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject GameManager;
    public GameObject itemText;
    private GameManagerScript manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            itemText.SetActive(true);
            itemText.GetComponent<UnityEngine.UI.Text>().text = "Hello! I'm Jesus Fish.";
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            //System.Threading.Thread.Sleep(3000);
            itemText.SetActive(false);
        }
    }
}
