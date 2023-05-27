using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: USE SCRIPTABLEOBJECTS
//TODO: SOME PROPERTIES COULD BE DESCRIBED IN A SUPER-CLASS OR AN INTERFACE, OR AGAIN, IN A SCRIPTABLEOBJECT
//TODO: IMPLEMENT, THEN EXTEND ABSTRACT CLASS AbstractEnemy ?

//TODO: CONVENIENT TO USE A SCRIPTABLE OBJECT HERE AS WELL. IT DEFINITELY CAN HELP CREATING AN MAINTAINING MULTIPLE VARIANTS.
//TODO: CAN EXTEND MonoSelfMoving

public class SpaceshipVisitor : Spaceship, ISelfMoving, ICanDamagePlayer
{
    //DATA
    //HEALTH & SCORING
    public int CollisionDamage = 1;

    //MOVEMENT
    Vector2 Velocity;
    public float speedModule = 2.0f;//USED TO CONTROL VISITOR DESCENT SPEED

    //BULLETS

    //TODO: MAX AMMO?
    //TODO: ELIGIBLE AS A SCRIPTABLEOBJECT CONTENT
    public float BulletCooldown = 5.0f;//UNUSED
    private float BulletTimer = 1.0f;
    private float BulletTimerRandomizer = 4.0f;//TODO: COULD BE A SERIALIZED FIELD
    public GameObject VisitorBulletPrefab;





    //METHODS
    //TECHNICAL

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        BulletTimer += Random.Range(0, BulletTimerRandomizer);
        SetStartVelocity();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Move();
        if (GameStateController.Instance.IsPlaying && !GameStateController.Instance.IsRespawning)
        {
            HandleShooting();
        }

    }

    //



    //IMPLEMENTING ISelfMoving
    public void SetStartVelocity() => Velocity = Vector2.left * speedModule;

    //
    public void Move()
    { 
        transform.Translate(Velocity * Time.deltaTime);
    }



    //COLLISIONS
    //TODO: IMPROVE COLLISION MANAGEMENT. IT SHOULD BE HANDLED AT THE SPACESHIP LEVEL INSTEAD.
    private void OnTriggerEnter2D(Collider2D other)
    {
        SpaceshipPlayer target = other.gameObject.GetComponent<SpaceshipPlayer>();

        if (target != null)
        {
            DamagePlayer(target);
            this.ReceiveDamage(maxHealthPoints);
        }

    }

    //IMPLEMENTING ICanDamagePlayer
    //TODO: REFACTOR SO THAT IT CAN RECEIVE DAMAGE BASED ON A "IDamageable"? But it might make code harder.
    //TODO: SEE IF A BETTER IMPLEMENTATION CAN BE ACHIEVED BY USING THE SAME CODE IN Projectile CLASS
    public void DamagePlayer(SpaceshipPlayer player)
    {
        player.ReceiveDamage(CollisionDamage);
    }



    //SHOOTING
    public void HandleShooting()
    {
        BulletTimer -= Time.deltaTime;
        if (BulletTimer <= 0)
        {
            BulletTimer = BulletCooldown + Random.Range(0, BulletTimerRandomizer / 2);
            Shoot();
        }
    }


    public void Shoot()
    {
        //TODO: IMPLEMENT LOGIC. NO SHOOTING IF A NON-PLAYER ENTITY IS IN FRONT OF THIS VISITOR ?
        Vector3 add = Vector2.left;
        GameObject.Instantiate(
            VisitorBulletPrefab, 
            this.transform.position + add, 
            Quaternion.identity, 
            null
        );

    }


}
