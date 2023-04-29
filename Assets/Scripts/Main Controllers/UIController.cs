using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    //DATA
    public Text ScoreText;
    public Text LifeCount;

    public GameObject GameOverPanel;
    public GameObject StartGamePanel;
    public GameObject PauseGamePanel;
    public GameObject HelpPanel;

    private List<GameObject> AllGamePanels;

    private UIPanelSequentiable myUIPS;



    //METHODS

    //TECHNICAL

    // Start is called before the first frame update
    public void Awake()
    {
        AllGamePanels = new List<GameObject> { GameOverPanel, StartGamePanel, PauseGamePanel, HelpPanel };

        //START UI Sequentiable Panel
        UIPanelSequentiable startUIPS = new UIPanelSequentiable(StartGamePanel);
        startUIPS.TakeOver(null);

        //DEFAULTING TO START
        myUIPS = startUIPS;
    }



    //FUNCTIONALITIES

    //text updates
    public void UpdateScoreText(int _value) => ScoreText.text = _value.ToString();
    public void UpdateLives(int _value) => LifeCount.text = _value.ToString();


    //GUI PANELS MANAGEMENT

    //HIDE ALL
    public void HideAllUI()
    {
        foreach (GameObject go in AllGamePanels)
        {
            go.SetActive(false);
        }
    }


    //GAME OVER PANEL
    public void ShowGameOver()
    {
        UIPanelSequentiable gameOverUIPS = new UIPanelSequentiable(GameOverPanel);
        gameOverUIPS.TakeOver(null);

        //DEFAULTING TO START
        myUIPS = gameOverUIPS;
    }


    //START GAME PANEL
    public void ShowStartGame()
    {
        UIPS_Pause newUIPS = new UIPS_Pause(StartGamePanel);
        newUIPS.TakeOver(null);
        myUIPS = newUIPS;
    }
    public void HideStartGame() => StartGamePanel.SetActive(false);


    //HELP PANEL
    public void ShowHelp()
    {
        UIPanelSequentiable helpUIPS = new UIPanelSequentiable(HelpPanel);
        helpUIPS.TakeOver(myUIPS);
        myUIPS = helpUIPS;
    }



    //PAUSE PANEL - GENERALIZED NAVIGATE BACK UI PANEL VIA ESC-BUTTON IMPLEMENTATION
    public void NavigateBack()
    {
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
    }

}
