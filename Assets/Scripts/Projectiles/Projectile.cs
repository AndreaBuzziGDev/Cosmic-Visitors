using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoSelfMoving
{
    //DATA
    private ProjectileSO ProjectileScriptableObject;


    //METHODS

    //TECHNICAL
    void Start()
    {
        StartRoutine();
    }


    private void OnDestroy()
    {
        //DESTROY PARTICLES
        if (ProjectileScriptableObject.OnDestroyParticle != null)
        {
            GameObject.Instantiate(ProjectileScriptableObject.OnDestroyParticle, this.transform.position, Quaternion.identity, null);
        }

        //DESTROY SOUND
        AudioController.Instance.PlayClip(ProjectileScriptableObject.OnTargetHitAudio);

    }





    //START ROUTINE
    protected override void StartRoutine()
    {
        ProjectileScriptableObject = mySMBObjectSO as ProjectileSO;
        Destroy(this.gameObject, ProjectileScriptableObject.MaxLifeTime);//DELAYED DESTRUCTION (MAX BULLET LIFETIME)
        AudioController.Instance.PlayClip(ProjectileScriptableObject.OnShotAudio);

        //BASE
        base.StartRoutine();
    }



    //COLLISIONS
    private void OnTriggerEnter2D(Collider2D other)
    {
        //IDamageable
        HandleCollisionLogicDamageable(other);

        //Projectile(s destroy each other)
        HandleCollisionLogicProjectile(other);

    }

    //COLLISION: DAMAGEABLE
    protected virtual void HandleCollisionLogicDamageable(Collider2D other)
    {
        IDamageable iDamageableTarget = other.gameObject.GetComponent<IDamageable>();
        if (iDamageableTarget != null)
        {
            SpaceshipPlayer hasPlayer = other.gameObject.GetComponent<SpaceshipPlayer>();
            if ((hasPlayer == null && ProjectileScriptableObject.HitsVisitors) || (hasPlayer != null && ProjectileScriptableObject.HitsPlayer))
            {
                InflictDamage(iDamageableTarget);
                if (!ProjectileScriptableObject.Penetrates) Destroy(this.gameObject);
            }
        }
    }

    //COLLISION: PROJECTILES
    protected virtual void HandleCollisionLogicProjectile(Collider2D other)
    {
        if (ProjectileScriptableObject.HitsOtherProjectiles)
        {
            Projectile otherProjectile = other.gameObject.GetComponent<Projectile>();
            if (otherProjectile != null)
            {
                //POTENCY TIER CHECK
                if (ProjectileScriptableObject.PotencyTier > otherProjectile.ProjectileScriptableObject.PotencyTier)
                {
                    Destroy(other.gameObject);
                }
                //DESTROY THIS PROJECTILE ON HIT UNLESS IT PENETRATES
                else if (!ProjectileScriptableObject.Penetrates)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }





    //FUNCTIONALITIES
    public void InflictDamage(IDamageable target)
    {
        target.ReceiveDamage(ProjectileScriptableObject.BulletDamage);
    }

}
