using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardHolderManager : MonoBehaviour
{
    [Header("Card Holder Parameters")]
    [SerializeField] private Transform _cardHolderPosition;
    [SerializeField] private GameObject _card;
    [SerializeField] private Card[] _cardSO;

    [Header("Card Parameters")]
    [SerializeField] private GameObject[] _plantedCards;
    private int _cost;
    private Sprite _icon;

    void Start()
    {
        _plantedCards = new GameObject[_cardSO.Length];

        for (int i=0;i<_cardSO.Length;i++)
        {
            CreateCard(i);
        }
    }

    private void CreateCard(int index)
    {
        var card = Instantiate(_card, _cardHolderPosition);
        CardManager cardManager= card.GetComponent<CardManager>();
        cardManager.CardSO = _cardSO[index];

        _plantedCards[index] = card;

        _icon = _cardSO[index].icon;
        _cost = _cardSO[index].cost;

        card.GetComponentInChildren<SpriteRenderer>().sprite=_icon;
        card.GetComponentInChildren<TMP_Text>().text = _cost.ToString();
    }

}
