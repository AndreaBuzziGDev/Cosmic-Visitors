using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SMBObject", menuName = "ScriptableObjects/SMBObjects")]
public class SMBObjectSO : ScriptableObject
{
    //TODO: eDirectionType somewhere else, in a dedicated class?
    public enum eDirectionType
    {
        Up,
        Down,
        Left,
        Right
    }

    //BULLET SPEED
    public eDirectionType Direction;
    public float verticalDirectionModule = 0.0f;//USED TO CONTROL RANDOM VERTICAL MOVEMENT
    public float SpeedModule = 10.0f;//USED TO CONTROL BACKGROUND MOVEMENT SPEED

    //OBJECT LIFETIME
    //TODO: USE ANOTHER SOLUTION?
    public float MaxLifeTime = 15.0f;

}
