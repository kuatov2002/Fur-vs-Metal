using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Card/New Card", fileName = "New Card", order = 51)]
public class Card : ScriptableObject
{
    public Sprite icon;
    public GameObject prefab;
    public int cost;
}
