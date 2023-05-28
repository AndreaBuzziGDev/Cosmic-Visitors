using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    //DATA
    CrateSO CrateScriptableObject;



    //COLLISIONS
    private void OnTriggerEnter2D(Collider2D other)
    {
        SpaceshipPlayer target = other.gameObject.GetComponent<SpaceshipPlayer>();

        if (target != null)
        {
            //TODO: USE THE SPECIFIC IMPLEMENTATION INSIDE EACH CrateSO TO DELIVER WHAT'S NEEDED
            CrateScriptableObject.PickUp(target);
            /*
            if (SpaceshipVisitorScriptableObject.CollidesWithPlayer)
            {
                DamagePlayer(target);
                this.ReceiveDamage(maxHealthPoints);
            }
            */
        }
    }




}
