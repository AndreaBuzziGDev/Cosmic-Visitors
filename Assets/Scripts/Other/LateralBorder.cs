using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralBorder : MonoBehaviour
{
    //COLLISIONS
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
