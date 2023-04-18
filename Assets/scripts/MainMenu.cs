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
        mainMenu = GameObject.Find(Constants.MAINMENU_CANVAS);
        loading = GameObject.Find(Constants.LOADING_CANVAS);
        tutorial = GameObject.Find(Constants.TUTORIAL_CANVAS);
        level = GameObject.Find(Constants.LEVEL_SELECTION_CANVAS);

        mainMenu.GetComponent<Canvas>().enabled = true;
        loading.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        level.GetComponent<Canvas>().enabled = false;

        AudioManager.instance.Play(Constants.SCENE_MAINMENU);
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
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void LevelSelection(Button button)
    {
        //DontDestroyOnLoad(gameObject);

        loading.GetComponent<Canvas>().enabled = true;
        level.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;

        string sceneName = Constants.SCENE_TUTORIAL;

        if (button.CompareTag(Constants.TAG_TUTORIAL))
        {
            sceneName = Constants.SCENE_TUTORIAL;
        }
        else if (button.CompareTag(Constants.TAG_LEVEL1))
        {
            sceneName = Constants.SCENE_LEVEL1;
        }
        else if (button.CompareTag(Constants.TAG_LEVEL2))
        {
            sceneName = Constants.SCENE_LEVEL2;
        }
        else if (button.CompareTag(Constants.TAG_LEVEL3))
        {
            sceneName = Constants.SCENE_LEVEL3;
        }
        else if (button.CompareTag(Constants.TAG_LEVEL4))
        {
            sceneName = Constants.SCENE_LEVEL4;
        }


        AudioManager.instance.Stop(Constants.SCENE_MAINMENU);
        StartCoroutine("loadScene", Utils.sceneIndexFromName(sceneName));
    }

    public IEnumerator loadScene(int sceneIndex)
    {
        //DontDestroyOnLoad(gameObject);
        //yield return new WaitForSeconds(2);
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        SceneManager.sceneLoaded += OnSceneLoaded;
        //asyncOperation.completed += (param) => { HideLoadingScreen(); };
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            //reset();           
        }
        else if (scene.buildIndex == 1)
        {
            // initiating game settings
            // Saving ui reference
            
            //GameObject exitButton = GameObject.FindGameObjectWithTag("QuitButton");
            //if (exitButton != null)
            //{
            //    Button quitbtn = exitButton.GetComponent<Button>();
            //    quitbtn.onClick.AddListener(ExitButton);
            //}

            //// Start countdown
            //StartCoroutine("startCountdown");
        }
    }

  
}
