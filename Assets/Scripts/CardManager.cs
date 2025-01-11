using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Card _cardSO;

    public Card CardSO
    {
        get => _cardSO;
        set => _cardSO = value;
    }

    private GameObject _draggingPet;
    private Pet _pet;

    private Vector2Int _gridSize = new Vector2Int(15, 5);
    private bool _isAvailableToBuild;

    // ����� ����� �� ���� X � Y
    private const int XOffset = -7;
    private const int YOffset = -3;


    private GridController _gridController;

    private void Awake()
    {
        _gridController=GridController.Instance;
        _gridController.Grid = new Pet[_gridSize.x + Math.Abs(XOffset), _gridSize.y + Math.Abs(YOffset)];
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _draggingPet = Instantiate(_cardSO.prefab);

        _pet = _draggingPet.GetComponent<Pet>();

        // �������� ������� ���� � ������� �����������
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        // ������������� ��������� ������� �������
        _draggingPet.transform.position = mouseWorldPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_draggingPet != null)
        {
            // �������� ������� ���� � ������� �����������
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            // ��������� ���������� �� �����
            int x = Mathf.RoundToInt(mouseWorldPos.x) - XOffset;
            int y = Mathf.RoundToInt(mouseWorldPos.y) - YOffset;

            // ���������, ��������� �� ������ � �������� �����
            _isAvailableToBuild = x >= 0 && x < _gridSize.x && y >= 0 && y < _gridSize.y;

            // ���������, ������ �� ������
            if (_isAvailableToBuild && IsPlaceTaken(x, y))
            {
                _isAvailableToBuild = false;
            }

            // ������ ���� ������� � ����������� �� ����������� ������
            _pet.SetColor(_isAvailableToBuild);

            // ��������� ������� �������
            _draggingPet.transform.position = new Vector3(x + XOffset, y + YOffset, 0);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_isAvailableToBuild)
        {
            Destroy(_draggingPet);
        }
        else
        {
            int x = Mathf.RoundToInt(_draggingPet.transform.position.x) - XOffset;
            int y = Mathf.RoundToInt(_draggingPet.transform.position.y) - YOffset;

            _gridController.Grid[x, y] = _pet;
            _pet.ResetColor();

            MiningTransition miningTransition = _draggingPet.GetComponent<MiningTransition>();
            miningTransition.IsBuildingPlaced = true;
        }
    }

    private bool IsPlaceTaken(int x, int y)
    {
        return _gridController.Grid[x, y] != null;
    }
}
