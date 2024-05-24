using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class DynamicGridLayout : MonoBehaviour
{
    private GridLayoutGroup gridLayoutGroup;
    private RectTransform rectTransform;

    public int columns = 5;  // S�tun say�s�
    public int rows = 8;     // Sat�r say�s�

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
        // Parent objesinin geni�lik ve y�ksekli�ini al
        float totalWidth = rectTransform.rect.width;
        float totalHeight = rectTransform.rect.height;

        // Padding de�erlerini hesaba kat
        float paddingWidth = gridLayoutGroup.padding.left + gridLayoutGroup.padding.right;
        float paddingHeight = gridLayoutGroup.padding.top + gridLayoutGroup.padding.bottom;

        // H�creler aras� bo�luklar� hesaba kat
        float spacingWidth = gridLayoutGroup.spacing.x * (columns - 1);
        float spacingHeight = gridLayoutGroup.spacing.y * (rows - 1);

        // Her h�crenin geni�li�ini ve y�ksekli�ini hesapla
        float cellWidth = (totalWidth - paddingWidth - spacingWidth) / columns;
        float cellHeight = (totalHeight - paddingHeight - spacingHeight) / rows;

        // H�cre boyutlar�n� kare olacak �ekilde ayarla
        float cellSize = Mathf.Min(cellWidth, cellHeight);

        // H�cre boyutlar�n� ayarla
        gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);
    }
}
