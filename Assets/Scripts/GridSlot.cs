using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSlot : MonoBehaviour, IDropHandler
{
    private PrefabManager prefabManager;
    private GridController gridController;
    private ScoreManager scoreManager;

    void Start()
    {
        prefabManager = FindObjectOfType<PrefabManager>();
        gridController = FindObjectOfType<GridController>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
        else
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem droppedItem = dropped.GetComponent<DraggableItem>();
            DraggableItem existingItem = transform.GetChild(0).GetComponent<DraggableItem>();

            if (droppedItem.value == existingItem.value)
            {
                int newValue = droppedItem.value * 2;
                scoreManager.AddScore(newValue);

                Destroy(dropped);
                Destroy(existingItem.gameObject);

                GameObject newItem = prefabManager.GetPrefab(newValue);

                if (newItem != null)
                {
                    Instantiate(newItem, transform);
                }
                else
                {
                    Debug.LogError("Prefab not found for value: " + newValue);
                }

                gridController.CheckAndUpdateMaxTileValue(newValue);
                droppedItem.Merge();
            }
        }
    }
}
