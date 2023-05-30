using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    //DATA
    public TMPro.TextMeshProUGUI ScoreText;
    public TMPro.TextMeshProUGUI LifeCount;

    public GameObject StartGamePanel;
    public GameObject PauseGamePanel;
    public GameObject RespawningGamePanel;
    public GameObject HelpPanel;
    public GameObject GameOverPanel;

    public List<GameObject> AllFullScreenPanels;

    //TODO: DISCARD.
    private UIPanelSequentiable myUIPS;

    public HealthBar HealthBar;




    //METHODS

    //TECHNICAL

    // Start is called before the first frame update
    //public void Start()




    //FUNCTIONALITIES
    //text updates
    public void UpdateScoreText(int _value) => ScoreText.text = "Score: " + _value.ToString();

    public void UpdateLives(int _value) => LifeCount.text = "Lives: " + _value.ToString();



    //TODO: HANDLE GUI PANELS IN A DEDICATED HELPER?

    //GUI PANELS MANAGEMENT

    //HIDE ALL
    public void HideAllFullScreenPanels()
    {
        foreach (GameObject go in AllFullScreenPanels)
        {
            if(go != null) go.SetActive(false);
        }
    }


    //START GAME PANEL
    public void ShowStartGame()
    {
        //TODO: DISMISS
        /*
        UIPS_Pause newUIPS = new UIPS_Pause(StartGamePanel);
        newUIPS.TakeOver(null);
        myUIPS = newUIPS;
        */
        StartGamePanel.SetActive(true);
    }
    public void HideStartGame() => StartGamePanel.SetActive(false);


    //HELP PANEL
    public void ShowHelp()
    {
        UIPanelSequentiable helpUIPS = new UIPanelSequentiable(HelpPanel);
        helpUIPS.TakeOver(myUIPS);
        myUIPS = helpUIPS;
    }


    //PAUSE PANEL
    //GENERALIZED NAVIGATE BACK UI PANEL VIA ESC-BUTTON IMPLEMENTATION
    public void NavigateBack()
    {
        //ESC UNPAUSES THE GAME
        if (GameStateController.Instance.IsPaused)
        {
            GameStateController.Instance.setState(GameStateController.eGameState.Playing);
        } 
        else if (!GameStateController.Instance.IsRespawning) 
        {
            GameStateController.Instance.setState(GameStateController.eGameState.Paused);
        }

        //CARRIED OVER FROM BREAKOUT - BUT DISMISSED
        /*
        if (myUIPS != null)
            //ESC BY DEFAULT CLOSES CURRENT MENU WHEN ANY ARE OPEN
            myUIPS = myUIPS.GoBack();
        else
        {
            //ESC BY DEFAULT OPENS PAUSE MENU WHEN NONE ARE OPEN
            UIPS_Pause newUIPS = new UIPS_Pause(PauseGamePanel);
            newUIPS.TakeOver(null);
            myUIPS = newUIPS;
        }
        */
    }

    public void ShowPause() => PauseGamePanel.SetActive(true);
    public void Hidepause() => PauseGamePanel.SetActive(false);//UNUSED



    //RESPAWNING PANEL
    public void ShowRespawning() => RespawningGamePanel.SetActive(true);
    public void HideRespawning() => RespawningGamePanel.SetActive(false);//UNUSED




    //GAME OVER PANEL
    public void ShowGameOver()
    {
        //CARRIED OVER FROM BREAKOUT - BUT DISMISSED
        /*
        UIPanelSequentiable gameOverUIPS = new UIPanelSequentiable(GameOverPanel);
        gameOverUIPS.TakeOver(null);

        //DEFAULTING TO START
        myUIPS = gameOverUIPS;
        */
        GameOverPanel.SetActive(true);
    }
    public void HideGameOver() => GameOverPanel.SetActive(false);


}
