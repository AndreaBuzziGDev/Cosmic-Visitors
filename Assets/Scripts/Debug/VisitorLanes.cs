using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorLanes : MonoBehaviour
{
    //DATA
    [SerializeField] float Length = 20.0f;

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        foreach(Vector3 visitorLanePosition in VisitorColumn.ColumnPositions)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(new Vector3(visitorLanePosition.x - Length, visitorLanePosition.y, 0), new Vector3(visitorLanePosition.x, visitorLanePosition.y, 0));
        }
#endif
    }

}
