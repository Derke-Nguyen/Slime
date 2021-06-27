using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardInstance : Draggable
{
    public Card m_Card;
    public CardDisplay m_Display;

    public int m_Cost;

    public Player m_Player;

    public void InitCard(Player owner)
    {
        m_Player = owner;
        LoadCard(m_Card);
        m_Display.LoadCard(m_Card);
    }

    public void LoadCard(Card card)
    {
        if (card == null)
        {
            return;
        }
        m_Card = card;

        for (int i = 0; i < card.properties.Length; i++)
        {
            CardProperty property = card.properties[i];

            if (property.element is ElementInteger)
            {
                m_Cost = property.intValue;
            }
        }

    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        if(m_Cost > m_Player.GetMana())
        {
            IsHeld = false;
        }
    }

    public override void DroppedIn(Transform newParent)
    {

        if (IsHeld)
        {
            base.DroppedIn(newParent);
            m_Player.UseMana(m_Cost);
            if(m_Card.playEffect is SingleTargetEffect)
            {
                m_Card.playEffect.Execute();
            }

        }
    }
}
