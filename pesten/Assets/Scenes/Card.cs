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

            // Update the current suit if an 8 is played
            if (rank == 8)
            {
                gameManager.currentSuit = ChooseNewSuit(gameManager);
            }

            // End the player's turn
            gameManager.EndTurn();
        }
        else
        {
            // The card cannot be played, take appropriate action
            Debug.Log("Invalid move! The card cannot be played.");
        }
    }

    private bool IsPlayable(Card lastPlayedCard, string currentSuit)
    {
        // Implement the logic to determine if the card can be played based on the game rules
        // In Crazy 8's, the card can be played if it has the same suit or rank as the last played card,
        // or if it is an 8 and the player can choose a new suit.

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

        return false;
    }

    private string ChooseNewSuit(GameManager gameManager)
    {
        // Implement the logic for choosing a new suit when an 8 is played
        // This can be done through player input or AI logic

        // For simplicity, let's assume the new suit is chosen randomly
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        int randomIndex = Random.Range(0, suits.Length);
        return suits[randomIndex];
    }
}
