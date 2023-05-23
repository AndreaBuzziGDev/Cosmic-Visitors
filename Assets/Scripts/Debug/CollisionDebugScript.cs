using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDebugScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit me: " + this.gameObject.name);
    }


}
