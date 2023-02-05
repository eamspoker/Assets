using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControllerScript : MonoBehaviour
{
    public bool toggleMap = false;
    public Image map;
    public TMP_Text text;
    public Texture2D JesusFishTexture;
    public GameObject Pocket;
    public GameObject GameManager;
    private GameManagerScript manager;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void setToggle()
    {
        toggleMap = true;
    }
    
    #region pocket management

    public void CheckPockets()
    {
        //int i = 0;
        // while(i < Pocket.transform.childCount)
        // {
        //     if(manager.inventory["Jesus Fish"])
        // }
    }
    #endregion
}
