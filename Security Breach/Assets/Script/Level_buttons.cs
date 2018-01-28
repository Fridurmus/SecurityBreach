using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_buttons : MonoBehaviour {

	public Button level1;
	public Button level2;
	public Button level3;
	public Button level4;


	// Use this for initialization
	void Start () 
	{
		Button lvl1 = level1.GetComponent<Button> ();
		lvl1.onClick.AddListener (LevelOne);
		Button lvl2 = level2.GetComponent<Button> ();
		lvl2.onClick.AddListener (LevelTwo);
		Button lvl3 = level3.GetComponent<Button> ();
		lvl3.onClick.AddListener (LevelThree);
		Button lvl4 = level4.GetComponent<Button> ();
		lvl4.onClick.AddListener (LevelFour);
	}

	public void LevelOne()
	{
		Debug.Log ("ONE GO");
		SceneManager.LoadScene ("JP_Level1");
	}
	public void LevelTwo()
	{
		Debug.Log ("TWO GO");
		SceneManager.LoadScene ("JP_Level2");
	}
	public void LevelThree()
	{
		Debug.Log ("THREE GO");
		SceneManager.LoadScene ("level 1");
	}
	public void LevelFour()
	{
		Debug.Log ("FOUR GO");
		SceneManager.LoadScene ("level 2");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
