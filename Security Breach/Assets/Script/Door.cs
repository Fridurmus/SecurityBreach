using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Terminal[] NeededTerminals;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckItem())
        {
            gameObject.SetActive(false);
        }
	}

    bool CheckItem()
    {
        foreach (Terminal item in NeededTerminals)
        {
            if (item.triggered)
            {
                continue;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
