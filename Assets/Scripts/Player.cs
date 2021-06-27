using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int m_Mana = 1;
    private int m_MaxMana = 1;
    private int m_Health = 50;
    private int m_MaxHealth = 50;

    //Deck
    private Deck playerDeck;

    //Hand
    public GameObject playerHand;
    public Vector3 handPosition;
    public Text playerStats;

    //Board

    //public Card tempCard;
    private bool isTurn = false;

    public void Init()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        playerDeck = GetComponent<Deck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(playerStats != null)
        {
            playerStats.text = "Health: " + m_Health + "\nMana: " + m_Mana;
        }
    }

    public void DrawCard()
    {
        //add to hand
        GameObject drawnCard = playerDeck.DrawCard();
        drawnCard.transform.SetParent(playerHand.transform);
    }

    public void DrawCards(int numToDraw)
    {
        //add to hand
        for(int i = 0; i < numToDraw; i++)
        {
            GameObject drawnCard = playerDeck.DrawCard();
            drawnCard.transform.SetParent(playerHand.transform);
        }
    }

    public void SetTurn()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(handPosition, new Vector3(250, 300, 0));
    }

    public int GetMana()
    {
        return m_Mana;
    }

    public void UseMana(int cost)
    {
        m_Mana -= cost;
    }

    public void RoundStart()
    {
        m_MaxMana++;
        m_Mana = m_MaxMana;
        DrawCard();
    }
}
