using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    //DATA
    //CAPACITY
    [SerializeField] int maxCapacity = 3;
    [SerializeField] float currentCapacity = 3.0f;
    public int currentCells { get { return (int)currentCapacity; } }

    //RECHARGE
    [SerializeField] float rechargeTimer = 7.0f;
    [SerializeField] float currentRechargeTimer = 0.0f;
    [SerializeField] float rechargeFactor = 0.5f;
    public bool IsInRechargeCooldown { get { return currentRechargeTimer > 0.0f; } }


    //VISUAL FEEDBACK
    private SpriteRenderer shieldSprite;
    [SerializeField] float lingeringTimer = 3.0f;
    [SerializeField] float currentLingeringTimer = 0.0f;
    public bool IsLingering { get { return currentLingeringTimer > 0.0f; } }


    //AUDIO





    //METHODS

    //TECHNICAL

    // Start is called before the first frame update
    void Start()
    {
        currentLingeringTimer = lingeringTimer;
        shieldSprite = GetComponent<SpriteRenderer>();
        
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



    public void UpdateShieldBar()
    {
        //TODO: IMPLEMENT/UNCOMMENT
        //UIController.Instance.UpdateShieldBar(this);
    }



    //FUNCTIONALITIES
    public int TakeDamage(int incomingDamage)
    {

        Debug.Log("incomingDamage ENTER " + incomingDamage);
        Debug.Log("currentCapacity ENTER " + currentCapacity);
        Debug.Log("currentCells ENTER " + currentCells);

        //HANDLING CAPACITY CHANGES
        int outgoingDamage = incomingDamage - currentCells;
        if (outgoingDamage <= 0) outgoingDamage = 0;

        currentCapacity = currentCapacity - (incomingDamage - outgoingDamage);
        UpdateShieldBar();

        //COOLDOWN TO RECHARGE
        currentRechargeTimer = rechargeTimer;
        currentLingeringTimer = lingeringTimer;

        Debug.Log("currentCapacity OUT " + currentCapacity);
        Debug.Log("currentCells OUT " + currentCells);
        Debug.Log("incomingDamage " + incomingDamage);
        Debug.Log("outgoingDamage " + outgoingDamage);

        return outgoingDamage;
    }


    public void ManualRecharge(float rechargedCapacity)
    {
        currentCapacity += rechargedCapacity;
        if (currentCapacity > maxCapacity) currentCapacity = maxCapacity;

        //TODO: LINGER SHIELD AFTER MANUAL RECHARGE?

        UpdateShieldBar();
    }

    public void ManualBigRecharge(float rechargedCapacity)
    {
        //WILL IMMEDIATELY BYPASS COOLDOWNS
        currentRechargeTimer = 0;
        currentLingeringTimer = 0;

        ManualRecharge(rechargedCapacity);
    }

}
