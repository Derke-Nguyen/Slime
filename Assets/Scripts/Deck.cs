using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject tempCard;
    public Player owner;
    public List<GameObject> cards;

    public void Init()
    {
 
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            GameObject card = Instantiate(tempCard, transform);
            card.GetComponent<CardInstance>().InitCard(owner);
            cards.Add(card);
        }
    }

    public GameObject DrawCard()
    {
        GameObject card = cards[0];
        cards.Remove(card);
        return card;
    }
}
