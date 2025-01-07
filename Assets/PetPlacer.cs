using UnityEngine;

public class PetPlacer : MonoBehaviour
{
    public GameObject petPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = new Vector3Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y), 0);

            Instantiate(petPrefab, gridPos, Quaternion.identity);
        }
    }
}