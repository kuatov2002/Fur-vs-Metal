using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapClickHandler : MonoBehaviour
{
    public Tilemap tilemap;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);

            Debug.Log($" лик по €чейке: {cellPos}");

            // «десь можно добавить логику размещени€ питомцев
        }
    }
}