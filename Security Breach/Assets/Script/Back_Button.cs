using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back_Button : MonoBehaviour {

	public Button backButton;

	// Use this for initialization
	void Start () 
	{
		Button back = backButton.GetComponent<Button> ();
		back.onClick.AddListener (BackButton);	
	}
	
	public void BackButton()
	{
		Debug.Log ("GO BACK");
		SceneManager.LoadScene ("Main_menu");
	}



	void Update () 
	{
		
	}
}
