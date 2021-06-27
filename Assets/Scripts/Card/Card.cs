using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the container of properties that represent a card in game
/// </summary>
[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public PlayEffect playEffect;
    public CardType cardType;
    public CardProperty[] properties;
}
