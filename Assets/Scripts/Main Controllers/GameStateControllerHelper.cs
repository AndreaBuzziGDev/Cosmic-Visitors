using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: IF THE CODE NEEDS TO BE RE-USED FOR DIFFERENT SCENES (WITH A MAIN MENU SCENE), THEN TURN THIS INTO AN ABSTRACT CLASS, CONCRETE CLASSES WILL BE USED TO MANAGE CONTEXTUALITY
public class GameStateControllerHelper
{
    //STARTING
    public static void StartGame()
    {
        //RESET GAME
        GameController.Instance.HandleGameReset();

        //TODO: CARRIED OVER FROM BREAKOUT, MIGHT BECOME UNNECESSARY AFTER EDITS
        //TODO: THIS GAME WILL HAVE AN INTRO SEQUENCE (AS WELL AS LEVELING ONES) WHEN STARTING, EXPECT REWORKS
        //UIController.Instance.ShowStartGame();//RE-SHOW AFTER TURNING OFF ALL UIs

        //AFTER STARTING, PLAY
        GameStateController.Instance.setState(GameStateController.eGameState.Playing);

    }



    //PAUSING
    public static void PauseGame()
    {
        Time.timeScale = 0;
    }
    public static void UnpauseGame()
    {
        Time.timeScale = 1;
    }



    //RESPAWNING
    public static void HandleRespawning()
    {
        UIController.Instance.ShowRespawning();
    }



    //TODO: GAME OVER HANDLING




    //QUIT GAME
    public static void QuitGame()
    {
        Debug.Log("You Quit Game");

        //TODO: IMPLEMENT BACK TO START MENU

    }



    //EXIT GAME
    public static void ExitGame()
    {
        Application.Quit();
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

}
