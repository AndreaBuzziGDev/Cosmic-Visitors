using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{

    public void PressRestart()
    {
        GameStateController.Instance.setState(GameStateController.eGameState.Start);
    }


    public void PressQuit()
    {
        GameStateController.Instance.setState(GameStateController.eGameState.Quitting);
    }



    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
