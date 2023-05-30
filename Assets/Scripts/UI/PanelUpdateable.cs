using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUpdateable : MonoBehaviour
{
    //ENUMS
    public enum ePanelType
    {
        Start,
        Respawning
    }


    //DATA
    [SerializeField] string BaseText = "Mission will start in ";
    [SerializeField] private float timerMax = 3.0f;
    private float ActualTimer = 0.0f;

    public ePanelType PanelType = ePanelType.Start;

    //GUI TEXT REFERENCE
    public TMPro.TextMeshProUGUI RespawningText;





    //METHODS

    //TECHNICAL
    private void OnEnable()
    {
        ActualTimer = timerMax;
    }

    void Update()
    {
        ActualTimer -= Time.deltaTime;
        updateText();
        if (ActualTimer <= 0.0f)
        {
            switch (PanelType)
            {
                case ePanelType.Start:
                    //AFTER STARTING, PLAY
                    GameStateController.Instance.setState(GameStateController.eGameState.Playing);
                    break;
                case ePanelType.Respawning:
                    GameController.Instance.ResetPlayer();
                    GameStateController.Instance.setState(GameStateController.eGameState.Playing);
                    break;
            }
        }
    }


    //FUNCTIONALITIES
    private void updateText()
    {

        //CALC NUM
        string numberPart = getNumberPart();

        //CALC DOTS
        string dots = "";
        for (int i = 0; i < getHowManyDots() || i < 3; i++)
        {
            dots += ".";
        }

        //UPDATE GUI
        RespawningText.text = BaseText + numberPart + dots;
    }


    private string getNumberPart() => (1 + (int)ActualTimer).ToString();

    private int getHowManyDots()
    {
        return (int)((ActualTimer - (int)ActualTimer) / 0.34f) + 1;
    }


}
