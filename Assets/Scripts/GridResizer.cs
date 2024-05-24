using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class GridResizer : MonoBehaviour
{
    private RectTransform rectTransform;
    private GridLayoutGroup gridLayoutGroup;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        ResizeGrid();
    }

    void Update()
    {
        ResizeGrid();
    }

    private void ResizeGrid()
    {
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;
        int columnCount = gridLayoutGroup.constraintCount;

        float cellWidth = (parentWidth - (gridLayoutGroup.padding.left + gridLayoutGroup.padding.right + (gridLayoutGroup.spacing.x * (columnCount - 1)))) / columnCount;
        float cellHeight = cellWidth; // Kare hücreler için

        gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
    }
}
