using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Card _cardSO;

    public Card CardSO
    {
        get => _cardSO;
        set { _cardSO = value; }
    }

    private GameObject _draggingPet;
    private Pet _pet;


    private Vector2Int _gridSize=new Vector2Int(15,5);
    private bool _isAvailableToBuild;

    private Pet[,] _grid;

    private void Awake()
    {
        _grid = new Pet[_gridSize.x, _gridSize.y];
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_draggingPet != null)
        {
            // Получаем позицию мыши в мировых координатах
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Устанавливаем Z-координату в 0
            mouseWorldPos.z = 0;

            // Обновляем позицию объекта
            _draggingPet.transform.position = mouseWorldPos;
        }
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        _draggingPet = Instantiate(_cardSO.prefab);

        _pet = _draggingPet.GetComponent<Pet>();

        // Получаем позицию мыши в мировых координатах
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Устанавливаем Z-координату в 0, так как это 2D
        mouseWorldPos.z = 0;

        // Устанавливаем начальную позицию объекта
        _draggingPet.transform.position = mouseWorldPos;
    }



    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_isAvailableToBuild)
        {
            Destroy(_draggingPet);
        }
        else
        {
            _grid[(int)_draggingPet.transform.position.x, (int)_draggingPet.transform.position.y] = _pet;
        }
    }


    private bool IsPlaceTaken(int x, int y)
    {
        if (_grid[x,y]!=null)
        {
            return true;
        }

        return false;
    }
}
