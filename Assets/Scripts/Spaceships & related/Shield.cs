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
    [SerializeField] float lingeringTimer = 3.0f;
    [SerializeField] float currentLingeringTimer = 3.0f;


    //AUDIO





    //METHODS

    //TECHNICAL

    // Start is called before the first frame update
    void Start()
    {
        //


    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRechargeCooldown)
        {
            //UPDATE TIMERS
            currentRechargeTimer -= Time.deltaTime;
            currentLingeringTimer -= Time.deltaTime;
        } 
        else
        {
            //HANDLE RECHARGE & CAPACITY
            currentCapacity += (rechargeFactor * Time.deltaTime);
            if (currentCapacity > maxCapacity) currentCapacity = maxCapacity;

            UpdateShieldBar();
        }

        //HANDLE VISUAL LINGERING
        //TODO: USE currentLingeringTimer TO MAKE SURE THE SHIELD SLOWLY FADES TO TRANSPARENCY AFTER BEING HIT

    }


    //FUNCTIONALITIES
    public int TakeDamage(int incomingDamage)
    {
        //HANDLING CAPACITY CHANGES
        int outgoingDamage = incomingDamage;
        outgoingDamage -= currentCells;
        currentCapacity -= currentCells;
        UpdateShieldBar();

        //COOLDOWN TO RECHARGE
        currentRechargeTimer = rechargeTimer;
        currentLingeringTimer = lingeringTimer;

        return outgoingDamage;
    }


    public void ManualRecharge(float rechargedCapacity)
    {
        currentCapacity += rechargedCapacity;
        if (currentCapacity > maxCapacity) currentCapacity = maxCapacity;

        UpdateShieldBar();
    }


    public void UpdateShieldBar()
    {
        //TODO: IMPLEMENT/UNCOMMENT
        //UIController.Instance.UpdateShieldBar(this);
    }

}
