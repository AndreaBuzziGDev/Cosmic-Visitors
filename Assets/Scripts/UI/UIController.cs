using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    //DATA
    public TMPro.TextMeshProUGUI ScoreText;//TODO: TEXTMESHPRO
    public TMPro.TextMeshProUGUI LifeCount;//TODO: TEXTMESHPRO

    public GameObject StartGamePanel;
    public GameObject PauseGamePanel;
    public GameObject HelpPanel;
    public GameObject GameOverPanel;

    public List<GameObject> AllFullScreenPanels;

    private UIPanelSequentiable myUIPS;

    public HealthBar HealthBar;




    //METHODS

    //TECHNICAL

    // Start is called before the first frame update
    public void Start()
    {
        /*
         * CARRIED OVER FROM BREAKOUT
         * 
        //START UI Sequentiable Panel
        UIPanelSequentiable startUIPS = new UIPanelSequentiable(StartGamePanel);
        startUIPS.TakeOver(null);

        //DEFAULTING TO START
        myUIPS = startUIPS;
        */

    }








    //FUNCTIONALITIES

    //text updates
    public void UpdateScoreText(int _value) => ScoreText.text = "Score: " + _value.ToString();

    //TODO: USE EVENT-ORIENTED PROGRAMMING TO NOTIFY LIFE COUNT CHANGES?
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
