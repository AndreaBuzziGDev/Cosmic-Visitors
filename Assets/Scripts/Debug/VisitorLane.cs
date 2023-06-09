using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorLane : MonoBehaviour
{
    //DATA

    [SerializeField] float Start = -8.0f;
    [SerializeField] float Length = 20.0f;
    [SerializeField] float Height = 0.0f;

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(Start, Height, 0), new Vector3(Length, Height, 0));
#endif
    }

}
