using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VisitorSO", menuName = "ScriptableObjects/Visitor")]
public class SpaceshipVisitorSO : ScriptableObject
{
    //HEALTH & SCORING
    public bool CollidesWithPlayer = true;
    public int CollisionDamage = 1;
    public bool SelfDestructOnCollision = true;

    //MOVEMENT
    public float speedModule = 2.0f;//USED TO CONTROL VISITOR MOVEMENT SPEED

    //BULLETS
    public float BulletCooldown = 5.0f;
    public float BulletTimerRandomizer = 2.0f;
    public GameObject VisitorBulletPrefab;
    public int AmmoCount = 1;

    //CRATES
    public int crateChance = 1;//PERCENTAGE POINTS

}
