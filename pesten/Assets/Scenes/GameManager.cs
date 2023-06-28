using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Card lastPlayedCard; // Reference to the last card played
    public string currentSuit; // The current suit chosen when an 8 is played

    private bool isPlayerTurn; // Flag to determine if it's currently the player's turn

    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for player input to play a card
        if (isPlayerTurn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Simulating player selecting a card
                Card selectedCard = GetSelectedCard();

                // Play the selected card
                if (selectedCard != null)
                {
                    selectedCard.Play(this);
                }
            }
        }
        else
        {
            // Simulating the opponent's turn
            if (Input.GetKeyDown(KeyCode.O))
            {
                // Simulating opponent selecting a card
                Card selectedCard = GetSelectedOpponentCard();

                // Play the selected card
                if (selectedCard != null)
                {
                    selectedCard.Play(this);
                }
            }
        }
    }

    public void EndTurn()
    {
        // Switch the turn to the other player
        isPlayerTurn = !isPlayerTurn;

        // Perform any other necessary actions at the end of a turn
    }

    private Card GetSelectedCard()
    {
        // Check if the player clicked on a card
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                // Check if the clicked object is a Card
                Card selectedCard = hit.collider.GetComponent<Card>();

                // Return the selected card if it is valid
                if (selectedCard != null && selectedCard.IsPlayable(lastPlayedCard, currentSuit))
                {
                    return selectedCard;
                }
            }
        }

        return null;
    }

    private Card GetSelectedOpponentCard()
    {
        Card[] opponentCards = FindObjectsOfType<Card>();

        List<Card> playableCards = new List<Card>();

        // Find all playable cards for the opponent
        foreach (Card card in opponentCards)
        {
            if (card.IsPlayable(lastPlayedCard, currentSuit))
            {
                playableCards.Add(card);
            }
        }

        // Select a random card from the playable cards
        if (playableCards.Count > 0)
        {
            int randomIndex = Random.Range(0, playableCards.Count);
            return playableCards[randomIndex];
        }

        return null;
    }
}
