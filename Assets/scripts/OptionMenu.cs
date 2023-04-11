using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    private GameObject tutorial, option;


    void Start()
    {
        option = GameObject.Find("OptionMenuCanvas");
        tutorial = GameObject.Find("TutorialCanvas");
        option.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        ManageInput();
    }

    public void TutorialButton()
    {
        tutorial.GetComponent<Canvas>().enabled = true;
    }

    public void backToOptionMenuButton()
    {
        tutorial.GetComponent<Canvas>().enabled = false;
    }


    public void backToMainMenuButton()
    {
        tutorial.GetComponent<Canvas>().enabled = false;

        // load main menu scene
        SceneManager.LoadScene(Constants.SCENE_MAINMENU);

    }

    public void ExitButton()
    {
        Application.Quit();
    }


    void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionButton();
        }

    }

    public void OptionButton()
    {
        option.GetComponent<Canvas>().enabled = !option.GetComponent<Canvas>().enabled;
    }


}
