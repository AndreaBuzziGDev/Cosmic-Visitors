using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//NB: THIS COULD HAVE BEEN HANDLED AS A SINGLE SCRIPT "HealthBar" WITH OVERLOADED METHODS.
public class ShieldBar : MonoBehaviour
{
    public Image ShieldBarImg;

    public void UpdateShieldBar(Shield shield)
    {
        float normalizedHealth = (float)shield.currentCells / (float)shield.MaxCapacity;
        ShieldBarImg.fillAmount = normalizedHealth;
    }
}
