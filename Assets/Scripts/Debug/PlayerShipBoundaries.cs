using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipBoundaries : MonoBehaviour
{
    //DATA
    [SerializeField] float Start = -11;
    [SerializeField] float HorizontalLength = 2;

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(Start, 4, 0), new Vector3(Start + HorizontalLength, 4, 0));
        Gizmos.DrawLine(new Vector3(Start, -4, 0), new Vector3(Start + HorizontalLength, -4, 0));

#endif
    }

}
