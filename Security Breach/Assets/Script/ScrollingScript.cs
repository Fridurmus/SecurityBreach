using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollingScript : MonoBehaviour
{
    public GameObject creditsBox;

    private bool isScrolling;

    public float scrollSpeed;

	public float TimetoMenu;
	private float CounttoMenu;


	// Use this for initialization
	void Start ()
    {
        Setup();
		CounttoMenu = 0;
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
			CounttoMenu += Time.deltaTime;
        }
		if(CounttoMenu > TimetoMenu)
		{
			SceneManager.LoadScene ("Main_menu");
		}
    }


}
