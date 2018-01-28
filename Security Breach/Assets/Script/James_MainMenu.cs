using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class James_MainMenu : MonoBehaviour {

	public Button playButton;
	public Button controlsButton;
	public Button quitButton;
	public Button creditsButton;
	public Button levelButton;

	// Use this for initialization
	void Start () 
	{
		Button play = playButton.GetComponent<Button> ();
		play.onClick.AddListener (PlayGame);
		Button options = controlsButton.GetComponent<Button> ();
		options.onClick.AddListener (Options);
		Button quit = quitButton.GetComponent<Button> ();
		quit.onClick.AddListener (QuitGame);
		Button cred = creditsButton.GetComponent<Button> ();
		cred.onClick.AddListener (CreditButton);
		Button level = levelButton.GetComponent<Button> ();
		level.onClick.AddListener (LevelButton);
	}
	
	// Update is called once per frame


	public void PlayGame()
	{
		SceneManager.LoadScene ("level 1");
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

	public void LevelButton()
	{
		Debug.Log ("SELECT LEVEL");
		SceneManager.LoadScene ("Level Select");
	}
	public void CreditButton()
	{
		Debug.Log ("ROLE CREDITS");
		SceneManager.LoadScene ("Credits");
	}
		
}
