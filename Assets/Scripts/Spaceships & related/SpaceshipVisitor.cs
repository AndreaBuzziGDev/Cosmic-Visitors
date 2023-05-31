using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //MIRRORING SpaceshipVisitorSO DATA FOR INSTANCE
    public int AmmoCount;


    //METHODS
    //TECHNICAL

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        AmmoCount = SpaceshipVisitorScriptableObject.AmmoCount;
        BulletTimer += Random.Range(0, SpaceshipVisitorScriptableObject.BulletTimerRandomizer);
        SetStartVelocity();

        //TODO: SETUP RANDOMIZED CRATES
        //      IT MIGHT BE MORE CONVENIENT TO RELY ON LOOT TABLES IN A DEDICATED CONTROLLER AND INSTANCIATE AN OBJECT REFERENCED THERE.
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
                //COLLISION BEHAVIOUR NOT GOING TO WORK IF THE TARGET IS IN DAMAGE COOLDOWN
                if (!target.IsInDamageCooldown)
                {
                    DamagePlayer(target);
                    if(SpaceshipVisitorScriptableObject.SelfDestructOnCollision) this.ReceiveDamage(maxHealthPoints);
                }
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
        if(AmmoCount > 0)
        {
            BulletTimer -= Time.deltaTime;
            if (BulletTimer <= 0)
            {
                //RESET BULLET: BASE COOLDOWN + RANDOMIZED DELAY
                BulletTimer = SpaceshipVisitorScriptableObject.BulletCooldown + Random.Range(0, SpaceshipVisitorScriptableObject.BulletTimerRandomizer);
                Shoot();

                AmmoCount--;
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
