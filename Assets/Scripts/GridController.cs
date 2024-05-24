using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridController : MonoBehaviour
{
    public TextMeshProUGUI maxTileText;
    private List<Transform> gridSlots;
    private int maxTileValue = 16;

    void Start()
    {
        gridSlots = new List<Transform>();
        foreach (Transform slot in transform)
        {
            gridSlots.Add(slot);
        }
        UpdateMaxTileText();
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

    public int GetMaxTileValue()
    {
        return maxTileValue;
    }

    public void CheckAndUpdateMaxTileValue(int newValue)
    {
        if (newValue > maxTileValue)
        {
            maxTileValue = newValue;
            UpdateMaxTileText();
        }
    }

    private void UpdateMaxTileText()
    {
        maxTileText.text = maxTileValue.ToString();
    }
}
