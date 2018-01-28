using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class James_MainMenu : MonoBehaviour {

	public Button playButton;
	public Button controlsButton;
	public Button quitButton;
	public Button backButton;

	// Use this for initialization
	void Start () 
	{
		Button play = playButton.GetComponent<Button> ();
		play.onClick.AddListener (PlayGame);
		Button controls = controlsButton.GetComponent<Button> ();
		controls.onClick.AddListener (ShowControls);
		Button quit = quitButton.GetComponent<Button> ();
		quit.onClick.AddListener (QuitGame);
		Button back = backButton.GetComponent<Button> ();
		back.onClick.AddListener (BackButton);

	}
	
	// Update is called once per frame


	public void PlayGame()
	{
		SceneManager.LoadScene ("level 1");
	}
	public void ShowControls()
	{
		Debug.Log ("Options are shown");
		SceneManager.LoadScene ("Options");
	}
	public void QuitGame()
	{
		Debug.Log ("Game has quit");
		Application.Quit ();
	}
	public void BackButton()
	{
		Debug.Log ("GO BACK");
		SceneManager.LoadScene ("Main_menu");
	}
		
}
