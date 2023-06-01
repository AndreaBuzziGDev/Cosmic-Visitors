using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoSingleton<GameStateController>
{
    //ENUMS
    //STATES
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

    public bool IsStarting { get { return this.gameState == eGameState.Start; } }

    public bool IsPaused { get { return this.gameState == eGameState.Paused; } }

    public bool IsPlaying { get { return this.gameState == eGameState.Playing || this.gameState == eGameState.Respawning; } }

    public bool IsStrictlyPlaying { get { return this.gameState == eGameState.Playing; } }

    public bool IsRespawning { get { return this.gameState == eGameState.Respawning; } }

    public bool IsLeveling { get { return this.gameState == eGameState.Leveling; } }







    //METHODS

    //TECHNICAL


    //FUNCTIONALITIES
    //...
    public void setState(eGameState targetState)
    {
        gameState = targetState;
        switch (gameState)
        {
            case eGameState.Start:
                UIController.Instance.HideAllFullScreenPanels();
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

                break;
            case eGameState.Quitting:
                GameStateControllerHelper.ExitGame();
                break;
        }
    }

}
