using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSelfMoving : MonoBehaviour, ISelfMoving
{
    //DATA

    //OBJECT SPEED
    public SMBObjectSO mySMBObjectSO;
    protected Vector2 Velocity;


    //METHODS

    //TECHNICAL

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }


    //FUNCTIONALITIES
    //START ROUTINE
    protected virtual void StartRoutine() => SetStartVelocity();



    //IMPLEMENT ISelfMoving
    public void SetStartVelocity() => Velocity = GetBaseDirection() * mySMBObjectSO.SpeedModule;
    
    //TODO: EVALUATE DYNAMIC (non-kinematic) SOLUTION
    public void Move()
    {
        transform.Translate(Velocity * Time.deltaTime);
    }



    //UTILITIES

    //GET BASE DIRECTION
    //USEFUL FOR BOTH BASE SPEED AND BASE BULLET PLACEMENT
    public Vector2 GetBaseDirection()
    {
        return GetBaseDirection(mySMBObjectSO.Direction);
    }

    public Vector2 GetBaseDirection(SMBObjectSO.eDirectionType directionType)
    {
        Vector2 baseDirection = Vector2.zero;

        switch (directionType)
        {
            case SMBObjectSO.eDirectionType.Up:
                baseDirection = Vector2.up;
                break;
            case SMBObjectSO.eDirectionType.Down:
                baseDirection = Vector2.down;
                break;
            case SMBObjectSO.eDirectionType.Left:
                baseDirection = Vector2.left;
                break;
            case SMBObjectSO.eDirectionType.Right:
                baseDirection = Vector2.right;
                break;
        }

        return baseDirection;
    }

}
