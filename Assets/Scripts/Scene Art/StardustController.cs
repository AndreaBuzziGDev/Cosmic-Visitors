using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardustController : MonoSingleton<StardustController>
{
    //DATA
    //PARTICLE EFFECT REFERENCES
    public GameObject PlayingPE;
    public GameObject LevelingPE;


    //METHODS

    //TECHNICAL
    void Update()
    {

        /*
        PlayingPE.gameObject.SetActive(false);
        LevelingPE.gameObject.SetActive(false);
        */
        if (GameStateController.Instance.IsLeveling)
        {
            PlayingPE.gameObject.SetActive(false);
            LevelingPE.gameObject.SetActive(true);
        }
        else if (GameStateController.Instance.IsPlaying)
        {
            PlayingPE.gameObject.SetActive(true);
            LevelingPE.gameObject.SetActive(false);
        }
    }

}
