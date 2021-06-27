using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Unit")]
public class UnitCard : CardType
{
    public override void OnSetType(CardDisplay display)
    {
        display.statsHold.SetActive(true);
    }
}
