using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    private GameObject tutorial, optionMenu, option, controls;
    void Start()
    {
        optionMenu = GameObject.Find(Constants.OPTION_MENU_CANVAS);
        tutorial = GameObject.Find(Constants.TUTORIAL_CANVAS);
        controls = GameObject.Find(Constants.CONTROLS_CANVAS);
        option = GameObject.Find(Constants.OPTIONS_CANVAS);
        optionMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        controls.GetComponent<Canvas>().enabled = false;
        option.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        ManageInput();
    }

    public void TutorialButton()
    {
        tutorial.GetComponent<Canvas>().enabled = true;
        optionMenu.GetComponent<Canvas>().enabled = false;        
        controls.GetComponent<Canvas>().enabled = false;
        option.GetComponent<Canvas>().enabled = false;
    }

    public void backToOptionMenuButton()
    {
        optionMenu.GetComponent<Canvas>().enabled = true;
        controls.GetComponent<Canvas>().enabled = false;
        option.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
    }


    public void backToMainMenuButton()
    {
        tutorial.GetComponent<Canvas>().enabled = false;

        // load main menu scene
        SceneManager.LoadScene(Constants.SCENE_MAINMENU, LoadSceneMode.Single);

    }

    public void ExitButton()
    {
        Application.Quit();
    }

    void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OptionsMenuButton();
        }

    }

    public void OptionsMenuButton()
    {
        optionMenu.GetComponent<Canvas>().enabled = !optionMenu.GetComponent<Canvas>().enabled;
        Cursor.lockState = optionMenu.GetComponent<Canvas>().enabled ? CursorLockMode.None : CursorLockMode.Locked;
        Time.timeScale = optionMenu.GetComponent<Canvas>().enabled ? 0 : 1;
        if (optionMenu.GetComponent<Canvas>().enabled)
        {
            try
            {
                AudioManager.instance.Pause(GameController.currentLevel);
            }
            catch (System.Exception ex)
            {

                Debug.Log(ex.InnerException);
            }
        }
        else
        {
            try
            {
                AudioManager.instance.Play(GameController.currentLevel);
            }
            catch (System.Exception ex)
            {

                Debug.Log(ex.InnerException);
            }
        }
    }

    public void Replay()
    {
        SceneManager.LoadSceneAsync(Utils.currentSceneBuildIndex, LoadSceneMode.Single);
    }

    public void backToOptions()
    {
        controls.GetComponent<Canvas>().enabled = false;
        option.GetComponent<Canvas>().enabled = true;
        optionMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
    }

    public void ControlsButton()
    {
        optionMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        option.GetComponent<Canvas>().enabled = false;
        controls.GetComponent<Canvas>().enabled = true;
    }

    public void OptionButton()
    {
        optionMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        option.GetComponent<Canvas>().enabled = false;
        controls.GetComponent<Canvas>().enabled = false;
    }

}
