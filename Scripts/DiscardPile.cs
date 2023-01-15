using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscardPile : MonoBehaviour
{
    public List<Card> discardedCards = new List<Card>();
    public TextMeshProUGUI discardPileSizeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        discardPileSizeText.text = discardedCards.Count.ToString();
    }

    public Card GetCardFromDiscardPile(){
        if(discardedCards.Count > 0){
            Card drawedCard = discardedCards[0];
            discardedCards.Remove(drawedCard);
            return drawedCard;
        }
        return null;
    }

    public void AddCardToDiscardPile(Card newCard){
        Debug.Log("newCard: " + newCard.cardName);
        discardedCards.Add(newCard);
    }

    public void RemoveCardFromDiscardPile(Card card){
        discardedCards.Remove(card);
    }
}
