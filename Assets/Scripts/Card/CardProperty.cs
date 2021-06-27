using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// These are properties in the card that will be associated with and element and either an int, sprite, or string
/// </summary>
[System.Serializable]
public class CardProperty
{
    public string stringValue;
    public int intValue;
    public Sprite spriteValue;
    public Element element;
}
