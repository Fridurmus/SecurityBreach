using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        TestInput();
	}

    public void TestInput()
    {
        if(Input.GetKeyDown("t"))
        {
            Debug.Log("Key was pressed");
        }
    }

}
