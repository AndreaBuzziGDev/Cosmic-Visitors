using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEquipment : MonoBehaviour
{
    //ENUMS
    public enum eShipEquipmentType
    {
        SmallCannon,
        BigCannon,
        Shield,
        Barrier,
        Thruster
    }



    //DATA
    //TODO: WILL USE SCRIPTABLE OBJECTS TO DEFINE PROTOTYPES
    [SerializeField] eShipEquipmentType ShipEquipmentType = eShipEquipmentType.SmallCannon;





    //METHODS
    //TECHNICAL
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //



}
