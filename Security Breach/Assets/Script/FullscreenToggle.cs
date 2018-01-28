using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FullscreenToggle : MonoBehaviour {

    public Toggle fsToggle;
    public AudioSource audioSource;
    // Use this for initialization
    void Start() {
        fsToggle.onValueChanged.AddListener(delegate { fullScreenToggle(); });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void fullScreenToggle()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(1280, 720, false);
        }
        else
        {
            Screen.fullScreen = true;
        }
        audioSource.PlayOneShot(audioSource.clip);
    }
}
