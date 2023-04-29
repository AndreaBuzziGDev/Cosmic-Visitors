using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoSingleton<GameStateController>
{
    //DATA

    //TODO: USE ENUMS TO ADDRESS GAME STATES?
    //STATES
    //TODO: UN-STATIFY
    public static bool IsPlaying { get; private set; }//UNUSED
    public static bool IsPaused { get; private set; }


    //METHODS

    //TECHNICAL
    private void Awake()
    {
        PauseGame();
    }



    //FUNCTIONALITIES

    //START GAME
    public void StartGame()
    {
        ResetGame();
        UIController.Instance.NavigateBack();
        IsPlaying = true;
        UnpauseGame();
    }


    //RESET GAME
    public void ResetGame()
    {
        //TODO: THIS METHOD SHOULD PROBABLY BE IN GAMECONTROLLER
        //TODO: AND THEY SHOULD PROBABLY BE HANDLED BY A DEDICATED CLASS USED INSIDE GAMECONTROLLER
    }



    //STATE: PAUSE
    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {
        IsPaused = false;
        Time.timeScale = 1;
    }



    //QUIT GAME
    public void QuitGame()
    {
        Debug.Log("You Quit Game");

        //RESET GAME
        ResetGame();

        //PAUSE
        IsPlaying = false;
        PauseGame();

        //BACK TO START MENU
        UIController.Instance.ShowStartGame();
    }


    //EXIT GAME
    public void ExitGame()
    {
        Application.Quit();
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }


    //STATE: GAME OVER
    public void GameOver()
    {
        //TODO: IMPLEMENT
        //GameController.Instance.mainBall.Kill();

        UIController.Instance.ShowGameOver();
        IsPlaying = false;
        PauseGame();
    }


}
