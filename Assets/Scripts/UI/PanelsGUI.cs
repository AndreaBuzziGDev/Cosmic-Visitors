using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsGUI : MonoBehaviour
{

    public static void PressRestart()
    {
        GameStateController.Instance.setState(GameStateController.eGameState.Start);
    }

    public static void PressResume()
    {
        GameStateController.Instance.setState(GameStateController.eGameState.Start);
    }

    public static void PressQuit()
    {
        GameStateController.Instance.setState(GameStateController.eGameState.Quitting);
    }

}
