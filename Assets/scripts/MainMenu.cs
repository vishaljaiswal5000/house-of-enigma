using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject loading;
    private GameObject tutorial;
    

    void Start()
    {
        mainMenu = GameObject.Find("MainMenuCanvas");
        loading = GameObject.Find("LoadingCanvas");
        tutorial = GameObject.Find("TutorialCanvas");

        mainMenu.GetComponent<Canvas>().enabled = true;
        loading.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartButton()
    {
        loading.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene("Demo");
    }

    public void TutorialButton()
    {
        loading.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = true;
    }


    public void backToMainMenuButton()
    {
        loading.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = true;
        tutorial.GetComponent<Canvas>().enabled = false;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
