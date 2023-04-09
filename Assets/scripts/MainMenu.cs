using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject loading;

    void Start()
    {
        mainMenu = GameObject.Find("MainMenuCanvas");
        loading = GameObject.Find("LoadingCanvas");

        mainMenu.GetComponent<Canvas>().enabled = true;
        loading.GetComponent<Canvas>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartButton()
    {
        loading.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene("Demo");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
