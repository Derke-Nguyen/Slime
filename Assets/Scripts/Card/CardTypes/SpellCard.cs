using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Spell")]
public class SpellCard : CardType
{
    public override void OnSetType(CardDisplay display)
    {
        display.statsHold.SetActive(false);
    }
}
