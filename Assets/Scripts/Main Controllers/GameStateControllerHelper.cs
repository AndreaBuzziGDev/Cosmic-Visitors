using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateControllerHelper
{
    //STARTING
    public static void StartGame()
    {
        //DESTROY
        GameController.Instance.DeleteAllVisitors();

        //RESET
        GameController.Instance.HandleGameReset();
        UIController.Instance.ShowStartGame();
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



    //QUIT GAME
    public static void QuitGame()
    {
        Debug.Log("You Quit Game");
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
