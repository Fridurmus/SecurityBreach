﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class James_MainMenu : MonoBehaviour {

	public Button playButton;
	public Button controlsButton;
    public Button options;
	public Button quitButton;
	public Button creditsButton;
    

	// Use this for initialization
	void Start () 
	{
		Button play = playButton.GetComponent<Button> ();
		play.onClick.AddListener (PlayGame);

        Button controls = controlsButton.GetComponent<Button>();
        controls.onClick.AddListener(Controls);

        Button opt = options.GetComponent<Button> ();
		opt.onClick.AddListener (Options);

		Button quit = quitButton.GetComponent<Button> ();
		quit.onClick.AddListener (QuitGame);

		Button cred = creditsButton.GetComponent<Button> ();
		cred.onClick.AddListener (CreditButton);
	}
	
	// Update is called once per frame


	public void PlayGame()
	{
        Debug.Log("SELECT LEVEL");
        SceneManager.LoadScene("NewLevelSelect");
    }

    public void Controls()
    {
        Debug.Log("CONTROLS");
        SceneManager.LoadScene("Controls");
    }

	public void Options()
	{
		Debug.Log ("Options are shown");
		SceneManager.LoadScene ("Options_Menu");
	}
	public void QuitGame()
	{
		Debug.Log ("Game has quit");
		Application.Quit ();
	}
	public void CreditButton()
	{
		Debug.Log ("ROLE CREDITS");
		SceneManager.LoadScene ("Credits");
	}
		
}
