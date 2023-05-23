using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMovingBackgroundObject : MonoSelfMoving
{
    //DATA

    //OBJECT SPEED


    //METHODS

    //TECHNICAL
    void Start()
    {
        StartRoutine();
    }


    //START ROUTINE
    protected override void StartRoutine()
    {
        Destroy(this.gameObject, mySMBObjectSO.MaxLifeTime);//DELAYED DESTRUCTION (MAX OBJECT LIFETIME)
        base.StartRoutine();
    }


    //IMPLEMENT ISelfMoving
    //TODO: USE/INTRODUCE VERTICAL RANDOMIZATION IN Velocity
    /*
    public override void SetStartVelocity() => Velocity = GetBaseDirection(Direction) * SMObjectScriptableObject.SpeedModule;
    */


    //GET BASE DIRECTION
    //TODO: OPTIMIZE EXISTING IMPLEMENTATION IN Projectile


}
