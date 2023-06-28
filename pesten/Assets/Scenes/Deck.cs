using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    private int currentIndex = 0;

    public void Shuffle()
    {
        // Fisher-Yates shuffle algorithm
        for (int i = 0; i < cards.Count - 1; i++)
        {
            int randomIndex = Random.Range(i, cards.Count);
            Card temp = cards[randomIndex];
            cards[randomIndex] = cards[i];
            cards[i] = temp;
        }
    }

    public Card DrawCard()
    {
        if (currentIndex < cards.Count)
        {
            Card drawnCard = cards[currentIndex];
            currentIndex++;
            return drawnCard;
        }

        return null;
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }
}
