using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardustController : MonoSingleton<StardustController>
{
    //DATA
    //PARTICLE EFFECT REFERENCES
    public ParticleSystem PlayingPE;
    public ParticleSystem LevelingPE;
    bool HasPlayedLeveling = false;


    //METHODS

    //TECHNICAL
    void Update()
    {
        if (GameStateController.Instance.IsStarting || GameStateController.Instance.IsLeveling)
        {
            if (!HasPlayedLeveling)
            {
                LevelingPE.Clear();
                LevelingPE.Play();
                HasPlayedLeveling = true;
            }
        }
        else
        {
            HasPlayedLeveling = false;
        }
    }

}
