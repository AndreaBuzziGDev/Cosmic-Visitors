using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelRespawn : MonoBehaviour
{

    //DATA
    //TODO: USE GAME CONTROLLER FOR THESE DATA?
    [SerializeField] private float RespawnTimer = 0.0f;


    public TMPro.TextMeshProUGUI RespawningText;



    //METHODS

    //TECHNICAL
    private void OnEnable()
    {
        RespawnTimer = GameController.Instance.RespawnMaxTimer;
    }

    void Update()
    {
        RespawnTimer -= Time.deltaTime;
        updateRespawningText();
        if (RespawnTimer <= 0.0f)
        {
            GameController.Instance.ResetPlayer();
            GameStateController.Instance.setState(GameStateController.eGameState.Playing);
        }
    }


    //FUNCTIONALITIES
    private void updateRespawningText()
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
        RespawningText.text = "Respawning in " + numberPart + dots;
    }


    private string getNumberPart() => (1 + (int)RespawnTimer).ToString();

    private int getHowManyDots()
    {
        return (int)((RespawnTimer - (int)RespawnTimer) / 0.34f) + 1;
    }


}
