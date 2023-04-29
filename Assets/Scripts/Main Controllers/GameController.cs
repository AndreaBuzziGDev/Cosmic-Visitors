using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    //DATA
    public int Score = 0;

    private int Lives;//TODO: GETTER ETC
    public const int StartingLives = 3;

    //TECHNICAL
    public Spaceship PlayerShip;//TODO: GETTER ETC


    //METHODS

    //TECHNICAL
    public void Start()
    {
        //TODO: IMPLEMENT BASIC CONTROLS OVER TIME AND GAME STATE
        GameStateController.Instance.ResetGame();
        UIController.Instance.ShowStartGame();//RE-SHOW AFTER TURNING OFF ALL UIs

    }



    //SCORE
    public void AddScore(int _value)
    {
        Score += _value;
        UIController.Instance.UpdateScoreText(Score);
    }



    //LIVES
    public void ResetLives() => Lives = StartingLives;

    public void LifeLoss()
    {
        if (Lives > 0)
        {
            //TODO: IMPLEMENT RESETTING ETC

            //
            Lives--;

            //TODO: USE EVENT-ORIENTED PROGRAMMING
            UIController.Instance.UpdateLives(Lives);
        } 
        else
        {
            //GAME OVER
            GameStateController.Instance.GameOver();
        }
    }

}
