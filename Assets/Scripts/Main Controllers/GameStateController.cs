using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoSingleton<GameStateController>
{
    //ENUMS
    //STATES
    //TODO: INTRODUCE STATE THAT DRIVES BACK TO MAIN MENU (Exiting)
    public enum eGameState
    {
        Start,
        Playing,
        Respawning,
        Paused,
        Leveling,
        GameOver,
        Quitting
    }

    //DATA
    [SerializeField] private eGameState gameState = eGameState.Start;
    public bool IsPaused { get { return this.gameState == eGameState.Paused; } }

    public bool IsPlaying { get { return this.gameState == eGameState.Playing || this.gameState == eGameState.Respawning; } }

    public bool IsRespawning { get { return this.gameState == eGameState.Respawning; } }

    public bool IsLeveling { get { return this.gameState == eGameState.Leveling; } }







    //METHODS

    //TECHNICAL

    //
    public void setState(eGameState targetState)
    {
        Debug.Log("Target Game State: " + targetState);

        gameState = targetState;
        switch (gameState)
        {
            case eGameState.Start:
                GameStateControllerHelper.StartGame();
                break;

            case eGameState.Playing:
                GameStateControllerHelper.UnpauseGame();
                UIController.Instance.HideAllFullScreenPanels();
                break;

            case eGameState.Respawning:
                GameStateControllerHelper.HandleRespawning();
                break;

            case eGameState.Paused:
                GameStateControllerHelper.PauseGame();
                UIController.Instance.ShowPause();

                break;

            case eGameState.GameOver:
                UIController.Instance.ShowGameOver();
                //TODO: DECIDE WHAT HAPPENS WHEN THE GAME IS OVER

                break;
            case eGameState.Quitting:
                GameStateControllerHelper.ExitGame();
                break;
        }
    }



    //FUNCTIONALITIES
    //...

}
