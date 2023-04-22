using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour
{
    public static int currentLevel;
    public static int currentSceneName;
    internal static int currentSceneBuildIndex;

    public static int sceneIndexFromName(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string testedScreen = NameFromIndex(i);           
            if (testedScreen == sceneName)
                return i;
        }
        return -1;
    }

    private static string NameFromIndex(int BuildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }


    public static int getCurrentLevel()
    {
        return currentLevel;
    }

    public static int getLevelTimer()
    {

        int time = 0;
        switch (getCurrentLevel())
        {
            case 0:               
                time = Constants.TOTAL_TIME_LEVEL0;
                break;
            case 1:
                time = Constants.TOTAL_TIME_LEVEL1;
                break;
            case 2:
                time = Constants.TOTAL_TIME_LEVEL2;
                break;
            case 3:
                time = Constants.TOTAL_TIME_LEVEL3;
                break;
            case 4:
                time = Constants.TOTAL_TIME_LEVEL4;
                break;
            default:
                time = Constants.TOTAL_TIME_LEVEL0;
                break;
        }

        return time;
    }


    public static IEnumerator loadScene(int sceneIndex)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {

        }
        else if (scene.buildIndex == 1)
        {

        }
    }

}
