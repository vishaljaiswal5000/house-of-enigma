using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    // Layers
    public const string LAYER_INTERACTABLE = "Interactable";


    // Tags
    public const string TAG_TUTORIAL = "Level_Tutorial";
    public const string TAG_LEVEL1 = "Level_1";
    public const string TAG_LEVEL2 = "Level_2";
    public const string TAG_LEVEL3 = "Level_3";
    public const string TAG_LEVEL4 = "Level_4";
    public const string TAG_DOOR = "Door";
    public const string TAG_EXITDOOR = "ExitDoor";
    public const string TAG_LEVEL_TITLE = "LevelTitle";
    public const string TAG_LEVEL_DESCRIPTION = "LevelDescription";
    public const string TAG_OBJECTIVES_TITLE = "ObjectivesTitle";
    public const string TAG_OBJECTIVES_DESCRIPTION = "ObjectivesDescription";
    public const string TAG_INGAME_TUTORIAL = "InGameTutorial";
    public const string TAG_GAMECLUE = "GameClue";
    public const string TAG_LEVELINTRO_TITLE = "LevelIntroTitle";
    public const string TAG_LEVELINTRO_DESCRIPTION = "LevelIntroDescription";


    // Scenes
    public const string SCENE_MAINMENU = "MainMenu";
    public const string SCENE_TUTORIAL = "Level_Tutorial";
    public const string SCENE_LEVEL1 = "Level_1";
    public const string SCENE_LEVEL2 = "Level_2";
    public const string SCENE_LEVEL3 = "Level_3";
    public const string SCENE_LEVEL4 = "Level_4";

    // Scene build index
    public const int SCENE_MAINMENU_BUILDINDEX = 0;
    public const int SCENE_TUTORIAL_BUILDINDEX = 1;
    public const int SCENE_LEVEL1_BUILDINDEX = 2;
    public const int SCENE_LEVEL2_BUILDINDEX = 3;
    public const int SCENE_LEVEL3_BUILDINDEX = 4;
    public const int SCENE_LEVEL4_BUILDINDEX = 5;


    // Level Data 0

    public const string TITLE_LEVEL0 = "Tutorial Level \nInvestigate Surgery Room";
    public const string DESCRIPTION_LEVEL0 = "Find the clues in the hospital.";
    public const string OBJECTIVES_TITLE_LEVEL0 = "Items Found: {0}/3";
    public const string OBJECTIVES_DESCRIPTION_LEVEL0 = "\n1. Get the Brain Jar \n2. Schedule of the surgery \n3. Stolen Bird Sculpture \n";
    public const int TOTAL_NUMBERS_OF_GAMECLUES_LEVEL0 = 3;
    public const int TOTAL_TIME_LEVEL0 = 5 * 60;

    // Level Data 1

    public const string TITLE_LEVEL1 = "Welcome to Level 1\nThe Heist Begins";
    public const string DESCRIPTION_LEVEL1 = "Your objective is to infiltrate a hospital basement floor and collect three valuable pieces of evidence without getting caught by the agent. The hospital floor is divided into several rooms; you must find evidence there. Your task is to search and collect the evidence and avoid detection by the agent. Be careful not to make too much noise or leave any evidence of your presence, or the agent may become suspicious. If the agent spots you, they will chase and try to catch you. If you are caught, then the mission will end.\nYou have limited time to complete the task, so you will need to move quickly and efficiently.\nHere are a few insights from our intel:\n1. Check the autopsy room.\n2. Room with blue light.\n3. Check the doctor's room which has a mirror.\nYour ultimate goal is to collect all the evidence and reach the exit gate on time. Good luck!";
    public const string OBJECTIVES_TITLE_LEVEL1 = "Items Found: {0}/3";
    public const string OBJECTIVES_DESCRIPTION_LEVEL1 = "\n1. Get the Doctor's Notebook \n2. Schedule of the surgery \n3. Stolen Vase \n";
    public const int TOTAL_NUMBERS_OF_GAMECLUES_LEVEL1 = 3;
    public const int TOTAL_TIME_LEVEL1 = 5 * 60;

    // Level Data 2
    public const string TITLE_LEVEL2 = "Leve 2 \nInpatient Department";
    public const string DESCRIPTION_LEVEL2 = "Find the clues in the hospital.";
    public const string OBJECTIVES_TITLE_LEVEL2 = "Items Found: {0}/10";
    public const string OBJECTIVES_DESCRIPTION_LEVEL2 = "\n1. Watch record \n2. Schedule of the surgery \n3. Operating notes \n4. Syringe \n5. Get the Skull \n6. Medical record \n7. Scalpel \n8. Visceral specimen \n9. Medicine bottle \n10. Skeleton";
    public const int TOTAL_NUMBERS_OF_GAMECLUES_LEVEL2 = 10;
    public const int TOTAL_TIME_LEVEL2 = 5 * 60;
    // Level Data 3
    public const string TITLE_LEVEL3 = "Level 3\n Murder house";
    public const string DESCRIPTION_LEVEL3 = "Find the clues in the house";
    public const string OBJECTIVES_TITLE_LEVEL3 = "Items Found: {0}/3";
    public const string OBJECTIVES_DESCRIPTION_LEVEL3 = "\n1. Human Brain \n2. Weapon: Gun \n3. Trash bin \n";
    public const int TOTAL_NUMBERS_OF_GAMECLUES_LEVEL3 = 3;
    public const int TOTAL_TIME_LEVEL3 = 5 * 60;
    // Level Data 4
    public const string TITLE_LEVEL4 = "Testing Title";
    public const string DESCRIPTION_LEVEL4 = "Some dummy text for testing description";
    public const string OBJECTIVES_TITLE_LEVEL4 = "Items Found: {0}/3";
    public const string OBJECTIVES_DESCRIPTION_LEVEL4 = "\n1. Find item \n2. Find item \n3. Find item \n";
    public const int TOTAL_NUMBERS_OF_GAMECLUES_LEVEL4 = 3;
    public const int TOTAL_TIME_LEVEL4 = 5 * 60;


    // In Game Tutorial - Interactables messages
    public const string INGAME_TUTORIAL_INTERACT = "Press [E] to interact";
    public const string INGAME_TUTORIAL_COLLECT = "Press [E] to collect";

    public const string MESSAGE_EXIT_GATE = "Escape the location";

    // Game objects
    public const string OPTION_MENU_CANVAS = "OptionMenuCanvas";
    public const string TUTORIAL_CANVAS = "TutorialCanvas";
    public const string HUD_CANVAS = "HUDCanvas";
    public const string PLAYER_OBJECT = "PlayerObj";
    public const string LEVEL_COMPLETED_CANVAS = "LevelCompletedCanvas";
    public const string LEVEL_FAILED_CANVAS = "LevelFailedCanvas";
    public const string LEVEL_INTRO_CANVAS = "LevelIntroCanvas";
    public const string MAINMENU_CANVAS = "MainMenuCanvas";
    public const string LOADING_CANVAS = "LoadingCanvas";
    public const string LEVEL_SELECTION_CANVAS = "LevelSelectionCanvas";
    public const string OPTIONS_CANVAS = "OptionsCanvas";
    public const string CONTROLS_CANVAS = "ControlsCanvas";

    public const string LEVEL_FAILED_CANVAS_MESSAGE_FIELD = "FailedMessage";

    // Level Failed Messages

    public const string LEVEL_FAILED_MESSAGE_CAUGHT = "You were caught by the agent";
    public const string LEVEL_FAILED_MESSAGE_TIMEOUT = "You ran out of time";




}
