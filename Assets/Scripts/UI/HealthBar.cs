using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HealthBarImg;

    public void UpdateHealthBar(SpaceshipPlayer player)
    {
        float normalizedHealth = (float) player.CurrentHealthPoints / (float) player.MaxHealthPoints;
        HealthBarImg.fillAmount = normalizedHealth;
    }
}
