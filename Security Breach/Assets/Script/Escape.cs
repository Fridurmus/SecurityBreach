﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Escape : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			SceneManager.LoadScene ("NewLevelSelect");
		}
	}

}
