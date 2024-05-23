using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private List<Transform> gridSlots;

    void Start()
    {
        gridSlots = new List<Transform>();
        foreach (Transform slot in transform)
        {
            gridSlots.Add(slot);
        }
    }

    public List<Transform> GetEmptySlots()
    {
        List<Transform> emptySlots = new List<Transform>();

        foreach (Transform slot in gridSlots)
        {
            if (slot.childCount == 0)
            {
                emptySlots.Add(slot);
            }
        }

        return emptySlots;
    }
}
