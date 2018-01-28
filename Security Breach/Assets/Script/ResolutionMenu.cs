using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionMenu : MonoBehaviour
{
    public Dropdown resDropdown;
    Resolution[] resolutions;



    // Use this for initialization
    void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        //resDropdown.options.Add(new Dropdown.OptionData(Screen.currentResolution.ToString()));
        for (int i = 0; i < resolutions.Length; i++)
        {
            resDropdown.options.Add(new Dropdown.OptionData(resolutions[i].ToString()));
            resDropdown.value = i;
        }
        resDropdown.onValueChanged.AddListener(delegate { resolutionSet(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resolutionSet()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, true);
        }
        else
        {
            Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, false);
        }
        
    }
}