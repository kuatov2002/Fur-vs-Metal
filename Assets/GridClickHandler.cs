using UnityEngine;
using UnityEngine.Tilemaps;

public class GridClickHandler : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;
    public Color highlightColor = Color.green;  // ���� ���������
    private Color originalColor = Color.white;  // ������������ ���� �����

    private Vector3Int previousCellPos;

    void Update()
    {
        // ���������� ������� ���� � ������� �����������
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = grid.WorldToCell(mouseWorldPos);

        // ���� ���� ������������� �� ����� ������
        if (cellPos != previousCellPos)
        {
            // ��������������� ���� ���������� ������
            tilemap.SetColor(previousCellPos, originalColor);

            // ������������ ����� ������
            tilemap.SetColor(cellPos, highlightColor);

            previousCellPos = cellPos;
        }

        // ��������� �����
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($"���� �� ������: {cellPos}");
        }
    }
}