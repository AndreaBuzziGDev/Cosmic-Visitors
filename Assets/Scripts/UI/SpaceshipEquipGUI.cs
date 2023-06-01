using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEquipGUI : MonoBehaviour
{
    //DATA
    public TMPro.TextMeshProUGUI ResourceAmountText;

    //METHODS
    //TODO: SHOW COOLDOWN VIA GUI?

    public void UpdateGUI(SpaceshipEquipment equip)
    {
        if (equip.IsInfinite) ResourceAmountText.text = "";
        else ResourceAmountText.text = equip.ResourceAmount.ToString();
    }

}
