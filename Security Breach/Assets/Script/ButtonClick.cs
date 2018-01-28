using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button clickedButton;
    public AudioSource audioSource;

    private void Start()
    {
        clickedButton.onClick.AddListener(playOnClick);
    }

    public void playOnClick()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
