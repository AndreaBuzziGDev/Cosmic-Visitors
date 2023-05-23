using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardustController : MonoSingleton<StardustController>
{
    //ENUMS
    //TODO: MOVE SOMEWHERE ELSE
    public enum eGamePhase
    {
        Playing,
        Leveling,
        None
    }

    //DATA
    public eGamePhase phase = eGamePhase.None;

    //PARTICLE EFFECT REFERENCES
    public GameObject StardustPlayingPE;
    public GameObject StardustLeveingPE;


    //METHODS

    //TECHNICAL
    void Start()
    {
        setPhase(eGamePhase.None);
    }


    //FUNCTIONALITIES
    public void setPhase(eGamePhase targetPhase)
    {

        StardustPlayingPE.gameObject.SetActive(false);
        StardustLeveingPE.gameObject.SetActive(false);
        phase = targetPhase;

        switch (phase)
        {
            case eGamePhase.Playing:
                StardustPlayingPE.gameObject.SetActive(true);
                break;
            case eGamePhase.Leveling:
                StardustLeveingPE.gameObject.SetActive(true);
                break;
            case eGamePhase.None:
                //NOTHING
                break;
        }
    }

}
