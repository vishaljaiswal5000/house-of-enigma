using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int level;
    private Text levelTitle, levelDescription;
    private Text objectivesTitle, objectivesDescription;
    private Text levelIntroTitle, levelIntroDescription;
    private GameObject hudCanvas, levelCompletedCanvas, levelFailedCanvas, levelIntroCanvas, playerObj;
    private int totalClues;
    private PlayerInventory playerInventory;
    public bool exitGateOpen, levelCompleted;
    private string currentLevel;
    void Start()
    {
        init();
    }

    public void init()
    {
        //update level on shared class
        Utils.currentLevel = level;
        exitGateOpen = false;
        levelCompleted = false;
        hudCanvas = GameObject.Find("HUDCanvas");
        playerObj = GameObject.Find("PlayerObj");

        levelCompletedCanvas = GameObject.Find("LevelCompletedCanvas");
        levelFailedCanvas = GameObject.Find("LevelFailedCanvas");
        levelIntroCanvas = GameObject.Find("LevelIntroCanvas");

        levelFailedCanvas.GetComponent<Canvas>().enabled = false;
        levelCompletedCanvas.GetComponent<Canvas>().enabled = false;
        hudCanvas.GetComponent<Canvas>().enabled = false;

        levelTitle = GameObject.FindGameObjectWithTag(Constants.TAG_LEVEL_TITLE).GetComponent<Text>();
        levelDescription = GameObject.FindGameObjectWithTag(Constants.TAG_LEVEL_DESCRIPTION).GetComponent<Text>();
        objectivesTitle = GameObject.FindGameObjectWithTag(Constants.TAG_OBJECTIVES_TITLE).GetComponent<Text>();
        objectivesDescription = GameObject.FindGameObjectWithTag(Constants.TAG_OBJECTIVES_DESCRIPTION).GetComponent<Text>();

        levelIntroTitle = GameObject.FindGameObjectWithTag(Constants.TAG_LEVELINTRO_TITLE).GetComponent<Text>();
        levelIntroDescription = GameObject.FindGameObjectWithTag(Constants.TAG_LEVELINTRO_DESCRIPTION).GetComponent<Text>();
        playerInventory = playerObj.GetComponent<PlayerInventory>();
        getLevelDetails(level);

        StartCoroutine("showIntro");
    }

    IEnumerator showIntro()
    {

        levelIntroCanvas.GetComponent<Canvas>().enabled = true;
        yield return new WaitForSeconds(5);
        hudCanvas.GetComponent<Canvas>().enabled = true;
        levelIntroCanvas.GetComponent<Canvas>().enabled = false;
        yield return new WaitForSeconds(1);
        TimerController.StartTimer();
    }

    public void getLevelDetails(int level)
    {
        switch (level)
        {
            case 0:
                currentLevel = Constants.SCENE_TUTORIAL;
                levelTitle.text = Constants.TITLE_LEVEL0;
                levelDescription.text = Constants.DESCRIPTION_LEVEL0;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL0;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL0;
                totalClues = Constants.TOTAL_NUMBERS_OF_GAMECLUES_LEVEL0;
                break;
            case 1:
                currentLevel = Constants.SCENE_LEVEL1;
                levelTitle.text = Constants.TITLE_LEVEL1;
                levelDescription.text = Constants.DESCRIPTION_LEVEL1;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL1;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL1;
                totalClues = Constants.TOTAL_NUMBERS_OF_GAMECLUES_LEVEL1;
                break;
            case 2:
                currentLevel = Constants.SCENE_LEVEL2;
                levelTitle.text = Constants.TITLE_LEVEL2;
                levelDescription.text = Constants.DESCRIPTION_LEVEL2;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL2;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL2;
                totalClues = Constants.TOTAL_NUMBERS_OF_GAMECLUES_LEVEL2;
                break;
            case 3:
                currentLevel = Constants.SCENE_LEVEL3;
                levelTitle.text = Constants.TITLE_LEVEL3;
                levelDescription.text = Constants.DESCRIPTION_LEVEL3;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL3;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL3;
                totalClues = Constants.TOTAL_NUMBERS_OF_GAMECLUES_LEVEL3;
                break;
            case 4:
                currentLevel = Constants.SCENE_LEVEL4;
                levelTitle.text = Constants.TITLE_LEVEL4;
                levelDescription.text = Constants.DESCRIPTION_LEVEL4;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL4;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL4;
                totalClues = Constants.TOTAL_NUMBERS_OF_GAMECLUES_LEVEL4;
                break;
            default:
                currentLevel = Constants.SCENE_TUTORIAL;
                levelTitle.text = Constants.TITLE_LEVEL0;
                levelDescription.text = Constants.DESCRIPTION_LEVEL0;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL0;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL0;
                totalClues = Constants.TOTAL_NUMBERS_OF_GAMECLUES_LEVEL0;
                break;
        }

        levelIntroTitle.text = levelTitle.text;
        levelIntroDescription.text = levelDescription.text;
    }

    private void Update()
    {
        showGameClues();
        checkProgress();
    }

    public void checkProgress()
    {
        if (TimerController.remainingTime == 0 && !levelCompleted)
        {
            Time.timeScale = 0;
            levelFailedCanvas.GetComponent<Canvas>().enabled = true;
        }

        if (levelCompleted)
        {
            Time.timeScale = 0;
            levelCompletedCanvas.GetComponent<Canvas>().enabled = true;
        }
    }

    public void showGameClues()
    {
        Text objectivesTitle = GameObject.FindGameObjectWithTag(Constants.TAG_OBJECTIVES_TITLE).GetComponent<Text>();
        objectivesTitle.text = string.Format(Constants.OBJECTIVES_TITLE_LEVEL0, playerInventory.numberOfGameClues);

        if (playerInventory.numberOfGameClues == totalClues)
        {
            exitGateOpen = true;
            objectivesDescription.text = Constants.MESSAGE_EXIT_GATE;
        }
    }

}
