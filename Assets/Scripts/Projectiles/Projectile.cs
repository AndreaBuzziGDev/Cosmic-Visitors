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



    //START ROUTINE
    protected override void StartRoutine()
    {
        ProjectileScriptableObject = mySMBObjectSO as ProjectileSO;
        Destroy(this.gameObject, ProjectileScriptableObject.MaxLifeTime);//DELAYED DESTRUCTION (MAX BULLET LIFETIME)
        AudioController.Instance.PlayClip(ProjectileScriptableObject.OnShotAudio);
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

    protected virtual void HandleCollisionLogicDamageable(Collider2D other)
    {
        IDamageable iDamageableTarget = other.gameObject.GetComponent<IDamageable>();
        if (iDamageableTarget != null)
        {
            SpaceshipPlayer hasPlayer = other.gameObject.GetComponent<SpaceshipPlayer>();
            if (hasPlayer == null || ProjectileScriptableObject.HitsPlayer)
            {
                InflictDamage(iDamageableTarget);
                AudioController.Instance.PlayClip(ProjectileScriptableObject.OnTargetHitAudio);

                //TODO: DESTROY, UNLESS IT'S A PENETRATING BULLET...
                Destroy(this.gameObject);
            }
        }
    }

    protected virtual void HandleCollisionLogicProjectile(Collider2D other)
    {
        if (ProjectileScriptableObject.HitsOtherProjectiles)
        {
            Projectile otherProjectile = other.gameObject.GetComponent<Projectile>();
            if (otherProjectile != null)
            {
                AudioController.Instance.PlayClip(ProjectileScriptableObject.OnTargetHitAudio);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }





    //FUNCTIONALITIES
    //TODO: USE INTERFACE IBullet ?
    //TODO: PLAYER SHOULD NOT BE ABLE TO HARM THEMSELVES
    public void InflictDamage(IDamageable target)
    {
        //TODO: DEVELOP
        target.ReceiveDamage(ProjectileScriptableObject.BulletDamage);
    }

}