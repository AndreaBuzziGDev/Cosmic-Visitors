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

    //SCRIPTABLE OBJECTS
    [SerializeField]
    SpaceshipVisitorSO SpaceshipVisitorScriptableObject;

    //MOVEMENT
    Vector2 Velocity;

    //BULLET TIMER
    private float BulletTimer = 1.0f;




    //METHODS
    //TECHNICAL

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        BulletTimer += Random.Range(0, SpaceshipVisitorScriptableObject.BulletTimerRandomizer);
        SetStartVelocity();

        //TODO: SETUP RANDOMIZED CRATES
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
    public void SetStartVelocity() => Velocity = Vector2.left * SpaceshipVisitorScriptableObject.speedModule;
    public void Move() => transform.Translate(Velocity * Time.deltaTime);


    //COLLISIONS
    private void OnTriggerEnter2D(Collider2D other)
    {
        SpaceshipPlayer target = other.gameObject.GetComponent<SpaceshipPlayer>();

        if (target != null)
        {
            if (SpaceshipVisitorScriptableObject.CollidesWithPlayer)
            {
                DamagePlayer(target);
                this.ReceiveDamage(maxHealthPoints);
            }
        }

    }

    //IMPLEMENTING ICanDamagePlayer
    public void DamagePlayer(SpaceshipPlayer player)
    {
        player.ReceiveDamage(SpaceshipVisitorScriptableObject.CollisionDamage);
    }



    //SHOOTING
    public void HandleShooting()
    {
        if(SpaceshipVisitorScriptableObject.AmmoCount > 0)
        {
            BulletTimer -= Time.deltaTime;
            if (BulletTimer <= 0)
            {
                //RESET BULLET: BASE COOLDOWN + RANDOMIZED DELAY
                BulletTimer = SpaceshipVisitorScriptableObject.BulletCooldown + Random.Range(0, SpaceshipVisitorScriptableObject.BulletTimerRandomizer);
                Shoot();
            }
        }
    }


    public void Shoot()
    {
        Vector3 add = Vector2.left;
        GameObject.Instantiate(
            SpaceshipVisitorScriptableObject.VisitorBulletPrefab, 
            this.transform.position + add, 
            Quaternion.identity, 
            null
        );

    }


}