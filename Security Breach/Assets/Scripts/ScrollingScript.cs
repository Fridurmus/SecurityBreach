using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public GameObject creditsBox;

    private bool isScrolling;

    public float scrollSpeed;


	// Use this for initialization
	void Start ()
    {
        Setup();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Scroll();
	}

    void Setup()
    {
        isScrolling = true;
    }

    void Scroll()
    {
        if(isScrolling == true)
        {
            creditsBox.transform.Translate(Vector3.up * Time.deltaTime * scrollSpeed);
        }
    }


}
