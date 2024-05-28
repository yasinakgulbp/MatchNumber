using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
    #region Variables
    public TextMeshProUGUI maxTileText;
    private List<Transform> gridSlots;
    private int maxTileValue = 2;

    public Image newTileImage;
    [SerializeField] private Sprite[] tileImages; // Add this array to hold the tile images
    public GameObject newTilePanel; // Add a panel to show when a new max tile is achieved
    #endregion

    #region Unity Methods
    void Awake()
    {
        InitializeGridSlots();
    }

    void InitializeGridSlots()
    {
        gridSlots = new List<Transform>();
        foreach (Transform slot in transform)
        {
            gridSlots.Add(slot);
        }
        UpdateMaxTileText();
    }
    #endregion

    #region Public Methods
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

    public void CloseNewTilePanel()
    {
        // Resume game time and hide the new tile panel
        Time.timeScale = 1;
        newTilePanel.SetActive(false);
    }
    #endregion

    #region Private Methods
    private void UpdateMaxTileText()
    {
        maxTileText.text = maxTileValue.ToString();
        //ShowNewTilePanel();
    }

    private void ShowNewTilePanel()
    {
        // Find the image in the array that matches the maxTileValue
        foreach (var image in tileImages)
        {
            if (image.name == maxTileValue.ToString())
            {
                newTileImage.sprite = image;
                break;
            }
        }

        // Show the new tile panel and pause the game time
        newTilePanel.SetActive(true);
        Time.timeScale = 0;
    }
    #endregion
}
