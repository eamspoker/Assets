using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIControllerScript : MonoBehaviour
{
    public bool toggleMap = false;
    public Image map;
    public TMP_Text text;
    public Sprite JesusFish;
    public GameObject Pocket;
    public GameObject GameManager;
    private GameManagerScript manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.GetComponent<GameManagerScript>();
        map.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            toggleMap = !toggleMap;
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("ThePast");
        }
        if(toggleMap)
        {
           map.enabled = !map.enabled;
        }

        toggleMap = false;

        if(manager.updatingPockets)
        {
            CheckPockets();
            manager.updatingPockets = false;
        }
    }


    public void setToggle()
    {
        toggleMap = true;
    }
    
    #region pocket management

    public void CheckPockets()
    {
        int i = 0;
        while(i < Pocket.transform.childCount)
        {
            if(manager.inventory.Count > i)
            {
                if(manager.inventory[i] is string) 
                {
                    print((string)manager.inventory[i]);
                    Sprite newSource = FindSprite((string)manager.inventory[i]);
                    GameObject childPocket = Pocket.transform.GetChild(i).gameObject;
                    if(newSource != null)
                        childPocket.GetComponent<Image>().sprite = newSource;
                }
            } else {
                break;
            }
            i++;
        }
    }

    public Sprite FindSprite(string s)
    {
        if(String.Equals(s, "JesusFish"))
        {
            return JesusFish;
        } else {
            return null;
        }
    }
    #endregion
}
