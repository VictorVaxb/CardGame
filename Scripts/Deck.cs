using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public TextMeshProUGUI deckSizeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deckSizeText.text = deck.Count.ToString();
    }

    public Card DrawCardFromDeck(){
        if(deck.Count > 0){
            Card drawedCard = deck[0];
            deck.Remove(drawedCard);
            return drawedCard;
        }
        return null;
    }

    public void AddCardToDeck(Card newCard){
        deck.Add(newCard);
    }

    public void RemoveCardFromDeck(Card card){
        deck.Remove(card);
    }
}
