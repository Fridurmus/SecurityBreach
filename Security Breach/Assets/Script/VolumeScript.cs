using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour {

    public Slider volSlider;

	// Use this for initialization
	void Start () {
        volSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ValueChangeCheck()
    {
        Debug.Log(volSlider.value);
    }
}
