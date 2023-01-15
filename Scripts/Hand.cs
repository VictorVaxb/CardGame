using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Card> handCards = new List<Card>();
    private PanelHandUi panelHand;

    void Start()
    {
        panelHand = GameObject.FindGameObjectsWithTag("PanelHand")[0].GetComponent<PanelHandUi>();
    }

    public void AddCardToHand(Card newCard){
        handCards.Add(newCard);
        panelHand.RefreshPanelHand();
    }

    public void RemoveCardFromHand(Card card){
        handCards.Remove(card);
        panelHand.RefreshPanelHand();
    }

    public List<Card> GetAllcardsInHand(){
        return handCards;
    }

    public Card GetCardById(int cardId){
        if(handCards.Count > 0){
            for(int x = 0;x < handCards.Count;x++){
                Card card = handCards[x];
                if(card.cardId == cardId){
                    return card;
                }
            }
            Debug.Log("ERROR GetCardById no hay cartas en la mano con ese Id: " + cardId);
        }else{
            Debug.Log("ERROR GetCardById no hay cartas en la mano");
        }
        return null;
    }

    public void RemoveCardById(int cardId){
        Card cardToRemove = GetCardById(cardId);
        //Debug.Log("cardToRemove: " + cardToRemove.cardName);
        handCards.Remove(cardToRemove);
        panelHand.RefreshPanelHand();
    }
}
