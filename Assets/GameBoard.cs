using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public int rows = 5;
    public int columns = 9;
    public float cellSize = 1f;

    private GameObject[,] grid;

    void Start()
    {
        grid = new GameObject[rows, columns];
        CreateBoard();
    }

    void CreateBoard()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 position = new Vector3(col * cellSize, row * cellSize, 0);
                GameObject cell = new GameObject($"Cell {row},{col}");
                cell.transform.position = position;
                cell.transform.parent = transform;
            }
        }
    }
}