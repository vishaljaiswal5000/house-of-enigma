using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Text levelTitle;
    private Text levelDescription;
    private Text objectivesTitle, objectivesDescription;
    private GameObject hudCanvas;
    [SerializeField] private int level;
    private string currentLevel;
    void Start()
    {
        hudCanvas = GameObject.Find("HUDCanvas");
        hudCanvas.GetComponent<Canvas>().enabled = true;

        levelTitle = GameObject.FindGameObjectWithTag(Constants.TAG_LEVEL_TITLE).GetComponent<Text>();
        levelDescription = GameObject.FindGameObjectWithTag(Constants.TAG_LEVEL_DESCRIPTION).GetComponent<Text>();
        objectivesTitle = GameObject.FindGameObjectWithTag(Constants.TAG_OBJECTIVES_TITLE).GetComponent<Text>();
        objectivesDescription = GameObject.FindGameObjectWithTag(Constants.TAG_OBJECTIVES_DESCRIPTION).GetComponent<Text>();

        getLevelDetails(level);
    }

    public void getLevelDetails(int level)
    {
        switch (level)
        {
            case 0:
                currentLevel = Constants.SCENE_TUTORIAL;
                levelTitle.text = Constants.TITLE_LEVEL1;
                levelDescription.text = Constants.DESCRIPTION_LEVEL1;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL0;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL0;
                break;
            case 1:
                currentLevel = Constants.SCENE_LEVEL1;
                levelTitle.text = Constants.TITLE_LEVEL1;
                levelDescription.text = Constants.DESCRIPTION_LEVEL1;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL1;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL1;
                break;
            case 2:
                currentLevel = Constants.SCENE_LEVEL2;
                levelTitle.text = Constants.TITLE_LEVEL2;
                levelDescription.text = Constants.DESCRIPTION_LEVEL2;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL2;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL2;
                break;
            case 3:
                currentLevel = Constants.SCENE_LEVEL3;
                levelTitle.text = Constants.TITLE_LEVEL3;
                levelDescription.text = Constants.DESCRIPTION_LEVEL3;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL3;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL3;
                break;
            case 4:
                currentLevel = Constants.SCENE_LEVEL4;
                levelTitle.text = Constants.TITLE_LEVEL4;
                levelDescription.text = Constants.DESCRIPTION_LEVEL4;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL4;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL4;
                break;
            default:
                currentLevel = Constants.SCENE_TUTORIAL;
                levelTitle.text = Constants.TITLE_LEVEL0;
                levelDescription.text = Constants.DESCRIPTION_LEVEL0;
                objectivesTitle.text = Constants.OBJECTIVES_TITLE_LEVEL0;
                objectivesDescription.text = Constants.OBJECTIVES_DESCRIPTION_LEVEL0;
                break;
        }
    }


}
