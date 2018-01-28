using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButtonOptions : MonoBehaviour
{
    public Button backButton;
    private void Start()
    {
        backButton.onClick.AddListener(backHandler);
    }

    public void backHandler()
    {
        SceneManager.LoadScene("Main_menu");
    }
}