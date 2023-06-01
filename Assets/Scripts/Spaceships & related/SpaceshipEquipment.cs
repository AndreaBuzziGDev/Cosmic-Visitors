using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEquipment : MonoBehaviour
{
    //ENUMS
    public enum eShipEquipmentType
    {
        Cannon,
        Barrier,
        Thruster
    }



    //DATA
    [SerializeField] eShipEquipmentType ShipEquipmentType = eShipEquipmentType.Cannon;


    //TODO: THIS IS SCRIPTABLE OBJECT-WORTHY DATA
    [SerializeField] int ResourceCount = 1;
    [SerializeField] bool HasInfiniteCapacity = false;

    [SerializeField] bool IsFullAuto = true;//UNUSED
    [SerializeField] bool IsAvailableForUse = true;
    [SerializeField] float UsageCooldown = 1.0f;
    [SerializeField] float ActualCoolDown = 0.0f;

    [SerializeField] bool IsParented = false;


    //TODO: TOOLTIP
    //TODO: RENAME AS "EquipmentPrefab"
    [SerializeField] GameObject EquipmentContent;//BULLET PREFAB, SHIELD PREFAB...



    //METHODS
    //TECHNICAL

    private void Update()
    {
        ActualCoolDown -= Time.deltaTime;
        if (ActualCoolDown <= 0) 
        {
            IsAvailableForUse = true;
        }
    }


    //FUNCTIONALITIES
    public void Use()
    {
        //IF UNAVAILABLE FOR USE...
        if (!IsAvailableForUse)
        {
            return;
        }

        //IF AVAILABLE FOR USE...
        if (ResourceCount > 0)
        {
            UsageLogic();

            //MAKE UNAVAILABLE
            if (UsageCooldown > 0.0f)
            {
                IsAvailableForUse = false;
                ActualCoolDown = UsageCooldown;
            }
        }
    }


    private void UsageLogic()
    {
        switch (ShipEquipmentType)
        {
            case eShipEquipmentType.Cannon:
                GameObject.Instantiate(EquipmentContent, this.transform.position, Quaternion.identity, null);
                if (!HasInfiniteCapacity) ResourceCount--;
                break;

            case eShipEquipmentType.Barrier:
                //"PARENTED" BARRIER
                if (IsParented) GameObject.Instantiate(EquipmentContent, this.transform.position, Quaternion.identity, transform);
                //"FIRE AND FORGET" BARRIER
                else GameObject.Instantiate(EquipmentContent, this.transform.position, Quaternion.identity, null);
                break;

            case eShipEquipmentType.Thruster:
                //TODO: IMPLEMENT
                //THRUSTERS WILL:
                //1) "ROTATE" SPRITE
                //2) GRANT INVINCIBILITY FRAMES/IMMUNITY TO COLLISIONS
                //3) GRANT FURTHER INVINCIBILITY AFTER "THRUST" HAS BEEN PERFORMED
                //4) MOVE THE PLAYER - TODO: MIGHT NEED 2 THRUSTERS SO THAT IT MIGHT 

                break;
        }
    }

    public void Reload(int amount)
    {
        ResourceCount += amount;
    }

}
