using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spaceship : MonoBehaviour, IDamageable
{
    //DATA
    //HEALTH
    [SerializeField] 
    protected int maxHealthPoints = 1;
    public int MaxHealthPoints { get { return maxHealthPoints; } }

    [SerializeField]
    protected int currentHealthPoints;
    public int CurrentHealthPoints { get { return currentHealthPoints; } }


    //SCORING
    [SerializeField] 
    protected int scoreDestroy;
    public int ScoreDestroy { get { return scoreDestroy; } }
    


    //AUDIO
    public AudioClip OnHitAudio;
    public AudioClip OnKillAudio;

    //DEATH PARTICLE EFFECT
    public GameObject DeathExplosionPrefab;



    //METHODS

    //TECHNICAL
    void Start()
    {
        currentHealthPoints = maxHealthPoints;
    }


    //IMPLEMENT IDamageable
    public void ReceiveDamage(int damage)
    {
        //TODO: ARMOR? ARMOR CLASSES?
        currentHealthPoints -= damage;
        if (currentHealthPoints <= 0)
        {
            HandleZeroHP();
        }
        else
        {
            HandleDamageReceived();
        }
    }

    public virtual void HandleDamageReceived()
    {
        AudioController.Instance.PlayClip(OnHitAudio);
    }

    public virtual void HandleZeroHP()
    {
        //SPACESHIP DEATH
        AudioController.Instance.PlayClip(OnKillAudio);
        GameController.Instance.AddScore(scoreDestroy);
        Destroy(this.gameObject);

        //DEATH PARTICLE EFFECT
        GameObject deathParticle = Instantiate(DeathExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(deathParticle, 1.0f);
    }

}
