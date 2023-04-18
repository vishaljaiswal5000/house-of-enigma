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
        option = GameObject.Find(Constants.OPTION_MENU_CANVAS);
        tutorial = GameObject.Find(Constants.TUTORIAL_CANVAS);
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {            
            OptionButton();
        }

    }

    public void OptionButton()
    {
        option.GetComponent<Canvas>().enabled = !option.GetComponent<Canvas>().enabled;
        Cursor.lockState = option.GetComponent<Canvas>().enabled? CursorLockMode.None: CursorLockMode.Locked;
        Time.timeScale = option.GetComponent<Canvas>().enabled ? 0 : 1;
        if (option.GetComponent<Canvas>().enabled)
        {
            AudioManager.instance.Pause(GameController.currentLevel);
        }
        else
        {
            AudioManager.instance.Play(GameController.currentLevel);
        }
    }


}
