using UnityEngine;
using UnityEngine.Tilemaps;

public class GridClickHandler : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;
    public Color highlightColor = Color.green;  // ÷вет подсветки
    private Color originalColor = Color.white;  // ќригинальный цвет €чеек

    private Vector3Int previousCellPos;

    void Update()
    {
        // ќпредел€ем позицию мыши в мировых координатах
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = grid.WorldToCell(mouseWorldPos);

        // ≈сли мышь переместилась на новую €чейку
        if (cellPos != previousCellPos)
        {
            // ¬осстанавливаем цвет предыдущей €чейки
            tilemap.SetColor(previousCellPos, originalColor);

            // ѕодсвечиваем новую €чейку
            tilemap.SetColor(cellPos, highlightColor);

            previousCellPos = cellPos;
        }

        // ќбработка клика
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($" лик по €чейке: {cellPos}");
        }
    }
}