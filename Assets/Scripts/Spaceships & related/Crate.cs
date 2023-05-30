using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: CRATES WILL BE SELF MOVING MONOs
public class Crate : MonoBehaviour
{
    //ENUMS
    public enum eCrateContentType
    {
        SmallCannonEquip,//WILL NOT IMPLEMENT
        BigCannonEquip,
        ShieldEquip,
        BarrierEquip,
        ThrusterEquip,//WILL NOT IMPLEMENT
        Health
    }

    //DATA
    eCrateContentType crateContentType;
    public eCrateContentType CrateContentType { get { return crateContentType; } }

    //AMOUNT IN CRATE
    int resourceAmount = 1;
    public int ResourceAmount { get { return resourceAmount; } }

    //AUDIO
    public AudioClip OnPickupAudio;




    //METHODS

    //COLLISIONS
    private void OnTriggerEnter2D(Collider2D other)
    {
        SpaceshipPlayer target = other.gameObject.GetComponent<SpaceshipPlayer>();

        if (target != null)
        {
            //
            AudioController.Instance.PlayClip(OnPickupAudio);
            target.ReloadWeaponSystem(this);

            //CRATE IS DESTROYED AFTER IT IS PICKED UP
            Destroy(this.gameObject);
        }
    }






}
