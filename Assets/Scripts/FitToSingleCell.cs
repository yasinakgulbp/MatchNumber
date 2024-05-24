using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class FitToSingleCell : MonoBehaviour
{
    private GridLayoutGroup gridLayoutGroup;
    private RectTransform rectTransform;

    void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        // FitCellSize fonksiyonunu 0.1 saniye gecikmeli olarak çaðýr
        FitCellSize();
        Invoke("FitCellSize", 0.012f);
        //InvokeRepeating("FirCellSize", 3, 1);
    }

    private void FitCellSize()
    {
        // Grid'in geniþliðini ve yüksekliðini al
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        // Hücre boyutlarýný grid'in geniþliði ve yüksekliði kadar ayarla
        gridLayoutGroup.cellSize = new Vector2(width, height);
    }
}
