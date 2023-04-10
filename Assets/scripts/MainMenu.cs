using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject loading;
    private GameObject tutorial;
    private GameObject level;


    void Start()
    {
        mainMenu = GameObject.Find("MainMenuCanvas");
        loading = GameObject.Find("LoadingCanvas");
        tutorial = GameObject.Find("TutorialCanvas");
        level = GameObject.Find("LevelSelectionCanvas");

        mainMenu.GetComponent<Canvas>().enabled = true;
        loading.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        level.GetComponent<Canvas>().enabled = false;

    }


    // Update is called once per frame
    void Update()
    {

    }


    public void StartButton()
    {
        loading.GetComponent<Canvas>().enabled = false;
        level.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
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

    public void LevelSelection(Button button)
    {
        loading.GetComponent<Canvas>().enabled = true;
        level.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;

        if (button.CompareTag(Constants.TAG_TUTORIAL))
        {
            SceneManager.LoadScene(Constants.SCENE_TUTORIAL);
        }
        else if (button.CompareTag(Constants.TAG_LEVEL1))
        {
            SceneManager.LoadScene(Constants.SCENE_LEVEL1);
        }
        else if (button.CompareTag(Constants.TAG_LEVEL2))
        {
            SceneManager.LoadScene(Constants.SCENE_LEVEL2);
        }
        else if (button.CompareTag(Constants.TAG_LEVEL3))
        {
            SceneManager.LoadScene(Constants.SCENE_LEVEL3);
        }
        else if (button.CompareTag(Constants.TAG_LEVEL4))
        {
            SceneManager.LoadScene(Constants.SCENE_LEVEL4);
        }
    }

}
