using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    //DATA
    //SCORE & LEVEL
    private int Score = 0;
    private int CurrentLevel = 1;

    //LIVES
    private int lives;
    public int Lives { get { return lives; } }

    [SerializeField] private int startingLives = 3;
    public int StartingLives { get { return startingLives; } }



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
    }

    public void AddLevel(int _levels)
    {
        CurrentLevel += _levels;
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
            UIController.Instance.UpdateLives(lives);

            //RESPAWNING
            GameStateController.Instance.setState(GameStateController.eGameState.Respawning);
        } 
        else
        {
            //GAME OVER
            GameStateController.Instance.setState(GameStateController.eGameState.GameOver);
        }
    }

    //PLAYER SHIP
    public void ResetPlayer()
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

    }

    //DELETE ALL VISITORS
    public void DeleteAllVisitors()
    {
        foreach(SpaceshipVisitor visitor in FindObjectsOfType<SpaceshipVisitor>())
        {
            Destroy(visitor.gameObject);
        }
    }



}
