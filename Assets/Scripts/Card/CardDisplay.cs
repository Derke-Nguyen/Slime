using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card m_DisplayCard;
    public CardDisplayProperty[] m_Properties;
    public GameObject statsHold;

    public Card tempCard;

    //===================================================================================================
    //  CARD DISPLAYS
    //===================================================================================================

    public void LoadCard(Card card)
    {
        if(card == null)
        {
            return;
        }
        m_DisplayCard = card;

        card.cardType.OnSetType(this);

        for(int i = 0; i < card.properties.Length; i++)
        {
            CardProperty property = card.properties[i];
            CardDisplayProperty displayProperty = GetProperty(property.element);

            if(displayProperty == null)
            {
                continue;
            }

            if(property.element is ElementInteger)
            {
                displayProperty.text.text = property.intValue.ToString();
            }
            else if (displayProperty.element is ElementText)
            {
                displayProperty.text.text = property.stringValue;
            }
            else if(displayProperty.element is ElementImage)
            {
                displayProperty.image.sprite = property.spriteValue;
            }
        }
           
    }

    public CardDisplayProperty GetProperty(Element e)
    {
        CardDisplayProperty result = null;
        for(int i = 0; i < m_Properties.Length; i++)
        {
            if(m_Properties[i].element == e)
            {
                result = m_Properties[i];
                break;
            }
        }

        return result;
    }
}
