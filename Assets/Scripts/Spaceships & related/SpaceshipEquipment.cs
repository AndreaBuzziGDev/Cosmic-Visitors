using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEquipment : MonoBehaviour
{
    //ENUMS
    public enum eShipEquipmentType
    {
        SmallCannon,
        BigCannon,
        Barrier,
        Thruster
    }



    //DATA
    [SerializeField] eShipEquipmentType ShipEquipmentType = eShipEquipmentType.SmallCannon;


    //TODO: THIS IS SCRIPTABLE OBJECT-WORTHY DATA - SKIPPING DUE TO TIME LIMITS
    [SerializeField] int ResourceCount = 1;
    public int ResourceAmount { get { return ResourceCount; } }

    [SerializeField] bool HasInfiniteCapacity = false;
    public bool IsInfinite { get { return HasInfiniteCapacity; } }


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
        if (!HasInfiniteCapacity) ResourceCount--;

        switch (ShipEquipmentType)
        {

            case eShipEquipmentType.SmallCannon:
                GameObject.Instantiate(EquipmentContent, this.transform.position, Quaternion.identity, null);
                UIController.Instance.SmallCannonsGUI.UpdateGUI(this);
                break;
            case eShipEquipmentType.BigCannon:
                GameObject.Instantiate(EquipmentContent, this.transform.position, Quaternion.identity, null);
                UIController.Instance.BigCannonsGUI.UpdateGUI(this);
                break;

            case eShipEquipmentType.Barrier:
                //NB: BARRIER HAS BEEN DISCARDED DUE TO TIME LIMITS
                //"PARENTED" BARRIER
                if (IsParented) GameObject.Instantiate(EquipmentContent, this.transform.position, Quaternion.identity, transform);
                //"FIRE AND FORGET" BARRIER
                else GameObject.Instantiate(EquipmentContent, this.transform.position, Quaternion.identity, null);

                break;

            case eShipEquipmentType.Thruster:
                //NB: THRUSTERS HAVE BEEN DISCARDED DUE TO TIME LIMITS
                //THRUSTERS WILL:
                //1) "ROTATE" SPRITE
                //2) GRANT INVINCIBILITY FRAMES/IMMUNITY TO COLLISIONS
                //3) GRANT FURTHER INVINCIBILITY AFTER "THRUST" HAS BEEN PERFORMED
                //4) MOVE THE PLAYER - TODO: MIGHT NEED 2 THRUSTERS SO THAT IT MIGHT GO UP AND DOWN

                break;
        }
    }

    public void Reload(int amount)
    {
        ResourceCount += amount;
        switch (ShipEquipmentType)
        {

            case eShipEquipmentType.SmallCannon:
                UIController.Instance.SmallCannonsGUI.UpdateGUI(this);
                break;
            case eShipEquipmentType.BigCannon:
                UIController.Instance.BigCannonsGUI.UpdateGUI(this);
                break;

            case eShipEquipmentType.Barrier:
                //UNUSED
                break;

            case eShipEquipmentType.Thruster:
                //UNUSED
                break;
        }

    }

}
