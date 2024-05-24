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
        // FitCellSize fonksiyonunu 0.1 saniye gecikmeli olarak �a��r
        FitCellSize();
        Invoke("FitCellSize", 0.012f);
        //InvokeRepeating("FirCellSize", 3, 1);
    }

    private void FitCellSize()
    {
        // Grid'in geni�li�ini ve y�ksekli�ini al
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        // H�cre boyutlar�n� grid'in geni�li�i ve y�ksekli�i kadar ayarla
        gridLayoutGroup.cellSize = new Vector2(width, height);
    }
}
