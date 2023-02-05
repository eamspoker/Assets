using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIControllerScript : MonoBehaviour
{
    public bool toggleMap = false;
    public bool togglePockets = false;
    public Image map;
    public TMP_Text text;
    public GameObject Pocket;
    public GameObject GameManager;
    private GameManagerScript manager;

    public Sprite nip;
    public Sprite blackberry;
    public Sprite seed;
     public Sprite cup;


    public Button mapButton;
    public Button pocketButton;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.GetComponent<GameManagerScript>();
        map.enabled = false;
        Pocket.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            setToggle();
            if(!map.enabled)
            {
                EventSystem.current.SetSelectedGameObject(mapButton.gameObject);
            }

        }

        if (Input.GetKeyDown("p"))
        {
            setPocketToggle();
            if(!Pocket.activeSelf)
            {
                EventSystem.current.SetSelectedGameObject(pocketButton.gameObject);
            }

        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("ThePast");
        }

        if(toggleMap && !Pocket.activeSelf)
        {
            if(map.enabled) EventSystem.current.SetSelectedGameObject(null);
           map.enabled = !map.enabled;
           toggleMap = false;
        }

         else if(togglePockets && !map.enabled)
        {
            if(Pocket.activeSelf) EventSystem.current.SetSelectedGameObject(null);
            Pocket.SetActive(!Pocket.activeSelf);
            togglePockets = false;
        }

    

        if(map.enabled && EventSystem.current.currentSelectedGameObject != mapButton.gameObject)
        {
            map.enabled = !map.enabled;
        }

        if(Pocket.activeSelf && EventSystem.current.currentSelectedGameObject != pocketButton.gameObject)
        {
            Pocket.SetActive(!Pocket.activeSelf);
        }


        

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
    public void setPocketToggle()
    {
        togglePockets = true;
    }
    
    public void CheckPockets()
    {
        GameObject PocketText = Pocket.transform.GetChild(4).gameObject;
        GameObject PocketIcon = Pocket.transform.GetChild(5).gameObject;

        int i = 0;
        while(i < PocketText.transform.childCount &&
            i < PocketIcon.transform.childCount)
        {
            if(manager.inventory.Count > i)
            {
                if(manager.inventory[i] is string) 
                {
                    Sprite newSource = FindSprite((string)manager.inventory[i]);
                    if(newSource != null)
                    {
                        
                        GameObject childPocket = PocketIcon.transform.GetChild(i).gameObject;
                        childPocket.GetComponent<Image>().sprite = newSource;
                        childPocket.GetComponent<Image>().color = Color.white;
                        GameObject childText = PocketText.transform.GetChild(i).gameObject;
                        childText.GetComponent<TMPro.TextMeshProUGUI>().text = (string)manager.inventory[i];

                    }
                }
            } else {
                break;
            }
            i++;
        }
    }

    public Sprite FindSprite(string s)
    {
        switch(s)
        {
            case "The Nip":
                return nip;
            case "Seed of Hope":
                return seed;
            case "Cat Cup":
                return cup;
            case "Royal Blackberry":
                return blackberry;
            default:
                return null;
        
        }
    }
    #endregion
}
