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
    private GameObject levelSelection;
    private GameObject options;
    private GameObject controls;
    private int level, sceneBuildIndex;
    

    void Start()
    {        
        mainMenu = GameObject.Find(Constants.MAINMENU_CANVAS);
        loading = GameObject.Find(Constants.LOADING_CANVAS);
        tutorial = GameObject.Find(Constants.TUTORIAL_CANVAS);
        levelSelection = GameObject.Find(Constants.LEVEL_SELECTION_CANVAS);
        options = GameObject.Find(Constants.OPTIONS_CANVAS);
        controls = GameObject.Find(Constants.CONTROLS_CANVAS);

        mainMenu.GetComponent<Canvas>().enabled = true;
        loading.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        levelSelection.GetComponent<Canvas>().enabled = false;
        options.GetComponent<Canvas>().enabled = false;
        controls.GetComponent<Canvas>().enabled = false;

        //play background music
        AudioManager.instance.Play(Constants.SCENE_MAINMENU);
    }

    public void StartButton()
    {
        loading.GetComponent<Canvas>().enabled = false;
        levelSelection.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        options.GetComponent<Canvas>().enabled = false;
        controls.GetComponent<Canvas>().enabled = false;
    }

    public void TutorialButton()
    {
        loading.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = true;
        options.GetComponent<Canvas>().enabled = false;
        controls.GetComponent<Canvas>().enabled = false;
    }


    public void backToMainMenuButton()
    {
        loading.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = true;
        tutorial.GetComponent<Canvas>().enabled = false;
        options.GetComponent<Canvas>().enabled = false;
        controls.GetComponent<Canvas>().enabled = false;
    }


    public void ExitButton()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OptionButton()
    {
        loading.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        options.GetComponent<Canvas>().enabled = true;
        controls.GetComponent<Canvas>().enabled = false;
    }

    public void ControlsButton()
    {
        loading.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        options.GetComponent<Canvas>().enabled = false;
        controls.GetComponent<Canvas>().enabled = true;
    }
  
    public void LevelSelection(Button button)
    {
        //DontDestroyOnLoad(gameObject);

        loading.GetComponent<Canvas>().enabled = true;
        levelSelection.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = false;
        tutorial.GetComponent<Canvas>().enabled = false;
        options.GetComponent<Canvas>().enabled = false;

        string sceneName = Constants.SCENE_TUTORIAL;

        if (button.CompareTag(Constants.TAG_TUTORIAL))
        {
            sceneName = Constants.SCENE_TUTORIAL;
            sceneBuildIndex = Constants.SCENE_TUTORIAL_BUILDINDEX;
            level = 0;
        }
        else if (button.CompareTag(Constants.TAG_LEVEL1))
        {
            sceneName = Constants.SCENE_LEVEL1;
            sceneBuildIndex = Constants.SCENE_LEVEL1_BUILDINDEX;
            level = 1;
        }
        else if (button.CompareTag(Constants.TAG_LEVEL2))
        {
            sceneName = Constants.SCENE_LEVEL2;
            sceneBuildIndex = Constants.SCENE_LEVEL2_BUILDINDEX;
            level = 2;
        }
        else if (button.CompareTag(Constants.TAG_LEVEL3))
        {
            sceneName = Constants.SCENE_LEVEL3;
            sceneBuildIndex = Constants.SCENE_LEVEL3_BUILDINDEX;
            level = 3;
        }
        else if (button.CompareTag(Constants.TAG_LEVEL4))
        {
            sceneName = Constants.SCENE_LEVEL4;
            sceneBuildIndex = Constants.SCENE_LEVEL4_BUILDINDEX;
            level = 4;
        }

        //update level on shared class
        Utils.currentLevel = level;
        Utils.currentSceneBuildIndex = sceneBuildIndex;


        AudioManager.instance.Stop(Constants.SCENE_MAINMENU);
        StartCoroutine("loadScene", Utils.sceneIndexFromName(sceneName));
    }

    public IEnumerator loadScene(int sceneIndex)
    {        
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;     
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
          
        }
        else if (scene.buildIndex == 1)
        {
          
        }
    }


}
