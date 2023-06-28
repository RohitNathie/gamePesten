using UnityEngine;

public class Card : MonoBehaviour
{
    public int rank; // The rank of the card (e.g., 1 for Ace, 2 for 2, 11 for Jack, etc.)
    public string suit; // The suit of the card (e.g., "Hearts", "Spades", etc.)

    public void Play(GameManager gameManager)
    {
        // Check if the card can be played based on the game rules
        if (IsPlayable(gameManager.lastPlayedCard, gameManager.currentSuit))
        {
            // Perform actions when the card is played
            gameManager.lastPlayedCard = this;

            // Add your own specific actions here, for example:
            Debug.Log("Card played: " + rank + " of " + suit);

            // End the player's turn
            gameManager.EndTurn();
        }
        else
        {
            // The card cannot be played, take appropriate action
            Debug.Log("Invalid move! The card cannot be played.");
        }
    }

    public void PlayCard(GameManager gameManager)
{
    // Check if the card is playable
    if (IsPlayable(gameManager.lastPlayedCard, gameManager.currentSuit))
    {
        // Perform actions for playing the card
        Debug.Log("Card played: " + rank + " of " + suit);

        // Update the game state with the last played card and current suit
        gameManager.lastPlayedCard = this;
        gameManager.currentSuit = suit;

        // End the turn
        gameManager.EndTurn();
    }
    else
    {
        // Card is not playable, so take appropriate action (e.g., show a message, highlight invalid selection, etc.)
        Debug.Log("Cannot play this card!");
    }
}


    public bool IsPlayable(Card lastPlayedCard, string currentSuit)
{
    // If the lastPlayedCard is null (e.g., first card of the game), any card can be played.
    if (lastPlayedCard == null)
    {
        return true;
    }

    // Check if the ranks or suits match
    if (rank == lastPlayedCard.rank || suit == lastPlayedCard.suit)
    {
        return true;
    }

    // Allow playing 8s regardless of the last played card
    if (rank == 8)
    {
        return true;
    }

    // Allow playing any card of the current suit
    if (suit == currentSuit)
    {
        return true;
    }

    return false;
}
}
