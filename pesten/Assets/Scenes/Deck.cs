using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    public List<Card> cards; // List of all the cards in the deck

    public void Shuffle()
    {
        // Implement the logic to shuffle the deck
    }

    public Card DrawCard()
    {
        // Implement the logic to draw a card from the deck
        // This involves removing a card from the list and returning it
        return null;
    }

    public void AddCard(Card card)
    {
        // Implement the logic to add a card to the deck
        // This involves adding the card to the list
    }
}
