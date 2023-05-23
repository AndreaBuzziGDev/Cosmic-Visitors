using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ProjectileScriptableObject", menuName ="ScriptableObjects/Projectile")]
public class ProjectileSO : SMBObjectSO //, ISelfMoving
{
    //TODO: REFACTOR SO THIS CONTAINS MOST OF THE PROJECTILE CODE
    //TODO: ENFORCE VERTICAL MOVEMENT TO 0? DEFINE VERTICAL MOVING BEHAVIOUR OVERRIDE?

    //BULLET DAMAGE PROPERTIES
    public bool HitsPlayer = false;
    public bool HitsOtherProjectiles = false;
    public int BulletDamage = 1;//TODO: INTERESTING EVOLUTIONS BASED ON DAMAGE TYPES?


    //AUDIO
    public AudioClip OnShotAudio;
    public AudioClip OnTargetHitAudio;



    //TODO: REFACTOR TAKING INSPIRATION FROM THE "ADVENTUREGAME FIXES"


}
