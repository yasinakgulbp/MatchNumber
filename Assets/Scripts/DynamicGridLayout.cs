using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class DynamicGridLayout : MonoBehaviour
{
    private GridLayoutGroup gridLayoutGroup;
    private RectTransform rectTransform;

    public int columns = 5;  // Sütun sayýsý
    public int rows = 8;     // Satýr sayýsý

    void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        ResizeGrid();
        Invoke("ResizeGrid", 0.005f);
        //InvokeRepeating("ResizeGrid", 2, 1);
    }

    private void ResizeGrid()
    {
        // Parent objesinin geniþlik ve yüksekliðini al
        float totalWidth = rectTransform.rect.width;
        float totalHeight = rectTransform.rect.height;

        // Padding deðerlerini hesaba kat
        float paddingWidth = gridLayoutGroup.padding.left + gridLayoutGroup.padding.right;
        float paddingHeight = gridLayoutGroup.padding.top + gridLayoutGroup.padding.bottom;

        // Hücreler arasý boþluklarý hesaba kat
        float spacingWidth = gridLayoutGroup.spacing.x * (columns - 1);
        float spacingHeight = gridLayoutGroup.spacing.y * (rows - 1);

        // Her hücrenin geniþliðini ve yüksekliðini hesapla
        float cellWidth = (totalWidth - paddingWidth - spacingWidth) / columns;
        float cellHeight = (totalHeight - paddingHeight - spacingHeight) / rows;

        // Hücre boyutlarýný kare olacak þekilde ayarla
        float cellSize = Mathf.Min(cellWidth, cellHeight);

        // Hücre boyutlarýný ayarla
        gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);
    }
}
