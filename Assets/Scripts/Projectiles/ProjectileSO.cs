using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ProjectileSO", menuName ="ScriptableObjects/Projectile")]
public class ProjectileSO : SMBObjectSO
{
    //BULLET DAMAGE PROPERTIES
    public bool HitsPlayer = false;
    public bool HitsOtherProjectiles = false;
    public bool HitsVisitors = false;

    //DAMAGE (& TYPES)
    public int BulletDamage = 1;
    public int PotencyTier = 1;
    public bool Penetrates = false;

    //AUDIO
    public AudioClip OnShotAudio;
    public AudioClip OnTargetHitAudio;

    //PARTICLES
    public ParticleSystem OnDestroyParticle;

}
