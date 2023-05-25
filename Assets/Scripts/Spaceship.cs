using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spaceship : MonoBehaviour, IDamageable
{
    //DATA
    //TODO: LOTS OF SPACESHIP-DEFINING DATA SHOULD PROBABLY FIT INSIDE A SCRIPTABLE OBJECTS INSTEAD

    //HEALTH
    [SerializeField] 
    protected int maxHealthPoints = 1;
    public int MaxHealthPoints { get { return maxHealthPoints; } }

    [SerializeField]
    protected int currentHealthPoints;
    public int CurrentHealthPoints { get { return currentHealthPoints; } }


    //DAMAGE COOLDOWN
    [SerializeField]
    protected float damageCooldownMax = 0.0f;//THIS HANDLES FOR HOW LONG THE OBJECT IS IMMUNE AFTER BEING HIT

    //TODO: CHECK IF IT MAKES SENSE TO MAKE PRIVATE
    [SerializeField]
    protected float damageCooldown = 0.0f;

    public bool IsInDamageCooldown { get { return damageCooldown > 0.0f; } }



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
    protected virtual void Awake()
    {
        currentHealthPoints = maxHealthPoints;
    }

    protected virtual void Update()
    {
        if (damageCooldown >= 0.0f)
        {
            damageCooldown -= Time.deltaTime;
        }
    }





    //IMPLEMENT IDamageable
    public void ReceiveDamage(int damage)
    {
        //HANDLE IMMUNITY TO DAMAGE
        if (!IsInDamageCooldown)
        {
            //RESET DAMAGE COOLDOWN
            damageCooldown = damageCooldownMax;

            //HANDLE HEALTH POINTS
            //TODO: ARMOR? ARMOR CLASSES?

            currentHealthPoints -= damage;
            if (currentHealthPoints > 0)
            {
                HandleDamageReceived();
            }
            else
            {
                HandleZeroHP();
            }
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
