using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoSingleton<GameStateController>
{
    //TODO: USE ENUMS TO ADDRESS GAME STATES?
    //STATES
    //TODO: UN-STATIFY
    public static bool IsPlaying { get; private set; }//UNUSED

    //ENUMS
    public enum eGameState
    {
        Start,
        Playing,
        Paused,
        GameOver,
        Quitting
    }

    //DATA
    private eGameState gameState = eGameState.Start;
    public bool IsPaused { get { return this.gameState == eGameState.Paused; } }






    //METHODS

    //TECHNICAL
    private void Start()
    {
        gameState = eGameState.Start;
    }


    //
    public void setState(eGameState targetState)
    {
        gameState = targetState;
        switch (gameState)
        {
            case eGameState.Start:
                GameStateControllerHelper.StartGame();
                break;

            case eGameState.Playing:
                GameStateControllerHelper.UnpauseGame();
                //TODO: HANDLE ADDITIONAL PLAYING THINGS (Disable Pause Menus)

                break;

            case eGameState.Paused:
                GameStateControllerHelper.PauseGame();
                //TODO: HANDLE ADDITIONAL PAUSED THINGS (Pause Menu)

                break;

            case eGameState.GameOver:
                //TODO: DECIDE WHAT HAPPENS WHEN THE GAME IS OVER
                UIController.Instance.ShowGameOver();

                break;
            case eGameState.Quitting:
                GameStateControllerHelper.ExitGame();
                break;
        }
    }



    //FUNCTIONALITIES
    //...

}
