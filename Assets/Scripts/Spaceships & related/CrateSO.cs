using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NB: NOT SETTING THESE PREVENTS THEM FROM SHOWING UP IN THE MENU?
//[CreateAssetMenu(fileName = "CrateSO", menuName = "ScriptableObjects/Crate")]
public abstract class CrateSO : ScriptableObject
{
    //TODO: STUDY A SOLUTION FOR HANDLING CRATE BEHAVIOURS
    //PERHAPS THE BEST IDEA COULD BE TO IMPLEMENT CODE DIRECTLY IN SCRIPTABLE OBJECT SUBCLASSES OF THIS CLASS
    public int HealingAmount = 0;

    public abstract void PickUp(SpaceshipPlayer target);

}
