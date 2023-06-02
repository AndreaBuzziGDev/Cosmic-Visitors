using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    //DATA
    //CAPACITY
    [SerializeField] int maxCapacity = 3;
    public int MaxCapacity { get { return maxCapacity; } }

    [SerializeField] float currentCapacity = 3.0f;
    public int currentCells { get { return (int)currentCapacity; } }

    //RECHARGE
    [SerializeField] float rechargeTimer = 7.0f;
    float currentRechargeTimer = 0.0f;
    public bool IsInRechargeCooldown { get { return currentRechargeTimer > 0.0f; } }

    //TEMPORAL FACTOR FOR RECHARGE
    [SerializeField] float rechargeFactor = 0.5f;


    //VISUAL FEEDBACK
    private SpriteRenderer shieldSprite;
    [SerializeField] float lingeringTimer = 3.0f;
    float currentLingeringTimer = 0.0f;

    public bool IsLingering { get { return currentLingeringTimer > 0.0f; } }


    //AUDIO
    bool HasRecharged = false;
    [SerializeField] AudioClip OnDamagedAudio;
    [SerializeField] AudioClip OnRechargeAudio;




    //METHODS

    //TECHNICAL

    // Start is called before the first frame update
    void Start()
    {
        currentLingeringTimer = lingeringTimer;
        shieldSprite = GetComponent<SpriteRenderer>();

        UpdateShieldBar();
    }

    // Update is called once per frame
    void Update()
    {
        //HANDLE LINGERING TIMER
        if (IsLingering) currentLingeringTimer -= Time.deltaTime;
        else currentLingeringTimer = 0.0f;

        //HANDLE COOLDOWN TIMER
        if (IsInRechargeCooldown)
        {
            //UPDATE TIMERS
            currentRechargeTimer -= Time.deltaTime;
        } 
        else
        {
            //WHEN SHIELD STARTS RECHARGING, PLAY AUDIO AND VIDEO FEEDBACK
            if (!HasRecharged)
            {
                AudioController.Instance.PlayClip(OnRechargeAudio);
                currentLingeringTimer = lingeringTimer;
                HasRecharged = true;
            }

            //HANDLE RECHARGE & CAPACITY
            currentCapacity += (rechargeFactor * Time.deltaTime);
            if (currentCapacity > maxCapacity) currentCapacity = maxCapacity;

            //TODO: IF DEV TIME IS LEFT, MAKE SHIELD FLICKER WHEN IT STARTS RECHARGING

            UpdateShieldBar();
        }

        //HANDLE VISUAL LINGERING & FADE
        if (currentCells > 0) ShieldProgressiveFade();
        else ShieldDown();
    }



    //COSMETHICS
    //TRANSPARENCY FADE
    private void ShieldProgressiveFade()
    {
        Color newColor = shieldSprite.color;
        newColor.a = Mathf.Lerp(0.0f, 1.0f, currentLingeringTimer / lingeringTimer);
        shieldSprite.color = newColor;
    }

    private void ShieldDown()
    {
        Color newColor = shieldSprite.color;
        newColor.a = 0;
        shieldSprite.color = newColor;
    }

    //GUI UPDATE
    public void UpdateShieldBar() => UIController.Instance.ShieldBar.UpdateShieldBar(this);



    //FUNCTIONALITIES
    public int TakeDamage(int incomingDamage)
    {
        //HANDLING CAPACITY CHANGES
        int outgoingDamage = incomingDamage - currentCells;
        if (outgoingDamage <= 0) outgoingDamage = 0;

        currentCapacity = currentCapacity - (incomingDamage - outgoingDamage);
        UpdateShieldBar();

        //COOLDOWN TO RECHARGE
        currentRechargeTimer = rechargeTimer;
        currentLingeringTimer = lingeringTimer;

        //SHIELD HAS NOT RECHARGED AFTER BEING HIT
        HasRecharged = false;

        //PLAY DAMAGE SOUND IF SHIELD HAS PROTECTED PLAYER
        if (incomingDamage > outgoingDamage)
        {
            AudioController.Instance.PlayClip(OnDamagedAudio);
        }

        return outgoingDamage;
    }


    public void ManualRecharge(float rechargedCapacity)
    {
        //HANDLE CAPACITY & MAX
        currentCapacity += rechargedCapacity;
        if (currentCapacity > maxCapacity) currentCapacity = maxCapacity;

        //LINGERS AFTER BEING MANUALLY CHARGED
        HasRecharged = false;

        //GUI UPDATE
        UpdateShieldBar();
    }

    //UNUSED
    public void ManualBigRecharge(float rechargedCapacity)
    {
        //SHIELD IMMEDIATELY STARTS RECHARGING
        currentRechargeTimer = 0;
        ManualRecharge(rechargedCapacity);
    }

}
