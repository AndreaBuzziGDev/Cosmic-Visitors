using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    //DATA
    private int Score = 0;
    private int CurrentLevel = 1;

    private int lives;
    public int Lives { get { return lives; } }

    public const int StartingLives = 3;

    //TECHNICAL
    //TODO: USE SERIALIZATION?
    public SpaceshipPlayer SpaceshipPlayerPrefab;


    //METHODS

    //TECHNICAL
    public void Start()
    {
        GameStateController.Instance.setState(GameStateController.eGameState.Start);
    }

    //SCORE
    public void ResetScore()
    {
        Score = 0;
        UIController.Instance.UpdateScoreText(Score);
    }

    public void AddScore(int _value)
    {
        Score += _value;
        UIController.Instance.UpdateScoreText(Score);
    }


    //LEVEL
    public void ResetLevel()
    {
        CurrentLevel = 0;
        //TODO: UPDATE UI CORRECTLY
        //UIController.Instance.UpdateScoreText(Score);
    }

    public void AddLevel(int _levels)
    {
        CurrentLevel += _levels;
        //TODO: UPDATE UI CORRECTLY
        //UIController.Instance.UpdateScoreText(Score);
    }



    //LIVES
    public void ResetLives() 
    {
        lives = StartingLives;
        UIController.Instance.UpdateLives(lives);
    }




    //HANDLE PLAYER DEATH
    public void LifeLoss()
    {
        if (lives > 0)
        {
            //
            lives--;

            //TODO: USE EVENT-ORIENTED PROGRAMMING
            UIController.Instance.UpdateLives(lives);

            //TODO: INTRODUCE "RESPAWNING" GAME STATE?

            //RE-INSTANCIATE PLAYER SHIP
            ResetPlayer();

        } 
        else
        {
            //GAME OVER
            GameStateController.Instance.setState(GameStateController.eGameState.GameOver);
        }
    }

    //PLAYER SHIP
    private void ResetPlayer()
    {
        //DESTROY PLAYER SHIP(s)
        SpaceshipPlayer[] foundPlayerShips = FindObjectsOfType<SpaceshipPlayer>();
        if (foundPlayerShips.Length > 0)
        {
            foreach (SpaceshipPlayer foundPlayerShip in foundPlayerShips) Destroy(foundPlayerShip.gameObject);
        }

        //CREATE NEW PLAYER SHIP
        SpaceshipPlayer newShip = GameObject.Instantiate(SpaceshipPlayerPrefab, Vector3.zero, Quaternion.identity, null);
        UIController.Instance.HealthBar.UpdateHealthBar(newShip);
    }




    //RESET GAME
    public void HandleGameReset()
    {
        //RESET LIVES
        ResetLives();

        //RESET SCORE
        ResetScore();

        //RESET LEVEL
        ResetLevel();

        //RESET PLAYER SHIP
        ResetPlayer();

        //TODO: RESET more?

    }



}
