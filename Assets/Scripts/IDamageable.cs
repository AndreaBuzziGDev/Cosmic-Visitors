using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{

    public void ReceiveDamage(int damage);

    public void HandleDamageReceived();

    public void HandleZeroHP();



    //TODO: ON KILL STUFF?
}
