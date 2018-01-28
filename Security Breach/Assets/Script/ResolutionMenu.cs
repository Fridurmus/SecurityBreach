//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ResolutionMenu : MonoBehaviour
//{
//    public Dropdown resDropdown;
//    Resolution[] resolutions;
//    // Use this for initialization
//    void Start()
//    {
//        Debug.Log(Screen.currentResolution);
//        resolutions = Screen.resolutions;
//        resDropdown.ClearOptions();
//        for (int i = 0; i < resolutions.Length; i++)
//        {
//            resDropdown.options.Add(new Dropdown.OptionData(resolutions[i].ToString()));
//            if (resolutions[i].ToString() == Screen.currentResolution.ToString())
//            {
//                resDropdown.value = i;
//            }
//        }

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}