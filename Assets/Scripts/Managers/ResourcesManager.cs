using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public Card[] allCards;
    private Dictionary<string, Card> cardDict = new Dictionary<string, Card>();

    // Start is called before the first frame update
    void Start()
    {
        cardDict.Clear();
        for(int i = 0; i < allCards.Length; i++)
        {
            cardDict.Add(allCards[i].cardName, allCards[i]);
        }
    }

    public Card GetCardInstance(string id)
    {
        Card fromDict = GetCard(id);
        if(fromDict == null)
        {
            return null;
        }

        Card newInst = Instantiate(fromDict);
        newInst.cardName = fromDict.cardName;
        return newInst;
    }

    Card GetCard(string id)
    {
        Card result = null;
        cardDict.TryGetValue(id, out result);
        return result;
    }
}
