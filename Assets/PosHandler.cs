using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosHandler : MonoBehaviour
{
    public Transform PosLeftBottom;
    public Transform PosRightBottom;
    public Transform PosLeftTop;
    public Transform PosRightTop;
    [Header("Pos Target")]
    public List<PosBoxController> ListPos;

    public Transform GetSlotEmpty()
    {
        foreach (var item in ListPos)
        {
            if (!item.BoxController)
            {
                Debug.Log("co");
                return item.transform;
            }
        }
        return null;
    }
}
