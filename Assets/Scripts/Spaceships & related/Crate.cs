using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoSelfMoving
{
    //ENUMS
    public enum eCrateContentType
    {
        SmallCannonEquip,//WILL NOT IMPLEMENT
        BigCannonEquip,
        ShieldCharge,
        BarrierEquip,
        ThrusterEquip,//WILL NOT IMPLEMENT
        Health
    }

    //DATA
    [SerializeField] eCrateContentType crateContentType;
    public eCrateContentType CrateContentType { get { return crateContentType; } }

    //AMOUNT IN CRATE
    [SerializeField] int resourceAmount = 1;
    public int ResourceAmount { get { return resourceAmount; } }




    //METHODS
    //TECHNICAL
    void Start()
    {
        StartRoutine();
    }



    //COLLISIONS
    private void OnTriggerEnter2D(Collider2D other)
    {
        SpaceshipPlayer target = other.gameObject.GetComponent<SpaceshipPlayer>();

        if (target != null)
        {
            //
            target.ReloadWeaponSystem(this);

            //CRATE IS DESTROYED AFTER IT IS PICKED UP
            Destroy(this.gameObject);
        }
    }

}
