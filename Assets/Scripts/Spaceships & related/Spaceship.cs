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

    protected int currentHealthPoints;
    public int CurrentHealthPoints { get { return currentHealthPoints; } }


    //DAMAGE HANDLING
    //TODO: SCRIPTABLE OBJECTS COULD HANDLE THE GENERAL GIST OF THIS PORTION OF CODE
    [SerializeField] protected Color regularColor = Color.white;
    [SerializeField] protected Color damagedColor = new Color(1,1,1,0);
    protected bool IsFlickeredDamage = false;

    [SerializeField] protected float damageCooldownMax = 0.1f;//THIS HANDLES FOR HOW LONG THE OBJECT IS IMMUNE AFTER BEING HIT
    [SerializeField] protected float damageCooldown = 0.0f;
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
        this.gameObject.GetComponent<SpriteRenderer>().color = regularColor;
    }

    protected virtual void Update()
    {
        HandleDamagedLifetime();
    }



    //FUNCTIONALITIES
    //HANDLE LIFETIME OF STATE: "DAMAGED"
    protected void HandleDamagedLifetime()
    {
        if (IsInDamageCooldown)
        {
            damageCooldown -= Time.deltaTime;
            if (IsFlickeredDamage)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = regularColor;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = damagedColor;
            }
            IsFlickeredDamage = !IsFlickeredDamage;
        }
        else
        {
            //RETURN TO NORMAL WHEN DAMAGE COOLDOWN IS OVER
            this.gameObject.GetComponent<SpriteRenderer>().color = regularColor;
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

        //DEATH PARTICLE EFFECT
        GameObject deathParticle = Instantiate(DeathExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(deathParticle, 1.0f);

        //DESTROY
        Destroy(this.gameObject);
    }

}
