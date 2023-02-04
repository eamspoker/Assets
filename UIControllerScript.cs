using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
    public bool toggleMap = false;
    public Image map;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        map.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
}
