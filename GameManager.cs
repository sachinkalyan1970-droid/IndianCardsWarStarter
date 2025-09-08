using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Card> deck = new List<Card>();
    private List<Card>[] playerHands = new List<Card>[4];
    private int currentDealer = 0;
    private int trumpBid = 0;
    private Suit trumpSuit;

    void Start()
    {
        InitializeDeck();
        ShuffleDeck();
        DealCards();
        StartBiddingPhase();
        PrintPlayerHands();
    }

    void InitializeDeck()
    {
        deck.Clear();
        foreach (Suit suit in System.Enum.GetValues(typeof(Suit)))
        {
            for (int value = 2; value <= 14; value++)
            {
                deck.Add(new Card(suit, value));
            }
        }
    }

    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(0, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    void DealCards()
    {
        for (int i = 0; i < 4; i++)
        {
            playerHands[i] = new List<Card>();
        }

        int cardIndex = 0;
        while (cardIndex < deck.Count)
        {
            for (int player = 0; player < 4; player++)
            {
                if (cardIndex < deck.Count)
                {
                    playerHands[player].Add(deck[cardIndex]);
                    cardIndex++;
                }
            }
        }
    }

    void StartBiddingPhase()
    {
        trumpSuit = (Suit)Random.Range(0, 4);
        trumpBid = Random.Range(8, 14);
        Debug.Log($"Trump Suit: {trumpSuit}, Trump Bid: {trumpBid}");
    }

    public void PrintPlayerHands()
    {
        for (int i = 0; i < 4; i++)
        {
            string hand = $"Player {i + 1}: ";
            foreach (var card in playerHands[i])
            {
                hand += $"{card.GetCardName()}, ";
            }
            Debug.Log(hand);
        }
    }
}
