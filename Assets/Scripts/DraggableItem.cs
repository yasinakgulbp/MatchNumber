using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public int value;
    private GridController gridController;
    private SpawnManager spawnManager;
    private bool merged = false;

    void Start()
    {
        gridController = FindObjectOfType<GridController>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

        if (!merged && transform.parent == parentAfterDrag)
        {
            spawnManager.TriggerPenaltySpawn();
        }

        merged = false;
    }

    public void Merge()
    {
        merged = true;
    }
}
