using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject GOverPanel;

    public Text textBox;

    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        TestInput();
	}

    public void gameOver()
    {
        GOverPanel.SetActive(true);
        StartCoroutine(ShowText());

    }

    public void TestInput()
    {
        if (Input.GetKeyDown("y"))
        {
            gameOver();
        }
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textBox.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }


    public void MainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("Main_Menu");
    }

    public void Level1()
    {
        SceneManager.LoadScene("level 1");
    }

    public void LevelSelect()
    {
        Debug.Log("SELECT LEVEL");
        SceneManager.LoadScene("Level Select");
    }
}
