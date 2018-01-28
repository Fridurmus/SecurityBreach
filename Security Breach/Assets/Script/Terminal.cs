using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Terminal : MonoBehaviour
{

    public bool triggerable = false;
    public bool triggered = false;
    Light ourLight;

    private void Start()
    {
        ourLight = gameObject.GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ourLight.color = Color.blue;
            //play sound effect
            triggerable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ourLight.color = Color.gray;
            triggerable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (triggerable && Input.GetButtonDown("use"))
        {
            triggered = true;
            //play sound effect
        }

        if (triggered)
        {
            ourLight.color = Color.green;
        }
    }
}
