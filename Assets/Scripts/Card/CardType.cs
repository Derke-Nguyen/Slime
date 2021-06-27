using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardType : ScriptableObject
{
    public string typeName;

    public abstract void OnSetType(CardDisplay display);
}
