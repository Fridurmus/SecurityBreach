using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour {

	public Button ResumeButton;
	public Button GoLevel;
	public Button GoMain;

	// Use this for initialization
	void Start () 
	{
		Button resume = ResumeButton.GetComponent<Button> ();
		resume.onClick.AddListener (ResumeGame);
		Button golvl = GoLevel.GetComponent<Button> ();
		golvl.onClick.AddListener (GotoLevel);
		Button gomain = GoMain.GetComponent<Button> ();
		gomain.onClick.AddListener (GotoMain);
	}

	public void ResumeGame()
	{
		Debug.Log ("RESUME GAME");
		Time.timeScale = 1;
		this.gameObject.SetActive (false);
	}
	public void GotoLevel()
	{
		Debug.Log ("GAME TO LEVEL");
		SceneManager.LoadScene ("Level Select");
	}
	public void GotoMain()
	{
		Debug.Log ("LEVEL TO MENU");
		SceneManager.LoadScene ("Main_menu");
	}
	





	void Update () {
		
	}
}
