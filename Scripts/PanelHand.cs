using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelHand : MonoBehaviour
{
    public Hand hand;
    public GameObject cardTemplate;
    private GameObject g;

    public void AddCardToPanelHand(Card newCard){
        g = cardTemplate;
        g.GetComponent<CardInPanel>().SetDataFromCard(newCard);
        Instantiate(g, this.transform);
    }

    public void RemoveCardFromPanelHand(Card cardToDelete){
        Debug.Log("RemoveCardFromPanelHand");
        GameObject cardGo = GetCardFromPanelHand(cardToDelete.cardId);
        Destroy(cardGo);
    }

    public GameObject GetCardFromPanelHand(int cardId){
        Debug.Log("GetCardFromPanelHand");
        GameObject[] cardsInHand = GameObject.FindGameObjectsWithTag("cardInHand");
        Debug.Log("Cards in Panel: " + cardsInHand.Length);
        if(cardsInHand.Length > 0){
            foreach(GameObject cardGo in cardsInHand){
                Card card = cardGo.GetComponent<Card>();
                if(card.cardId == cardId){
                    Debug.Log("Se encontro gameobject");
                    return cardGo;
                }
            }
            Debug.Log("ERROR no se encontro un Card con el Id: " + cardId);    
        }else{
            Debug.Log("ERROR no hay cartas en el panel hand");
        }
        return null;
    }

    public void RefreshPanelHand(){
        List<Card> cards = hand.GetAllcardsInHand();

        //find all cards in hand and destroy them
        GameObject[] cardsInHand = GameObject.FindGameObjectsWithTag("cardInHand");
        if(cardsInHand.Length > 0){
            foreach(GameObject card in cardsInHand){
                Destroy(card);
            }
        }

        for(int i = 0;i < cards.Count;i++){
            Card card = cards[i];
            g = cardTemplate;
            g.GetComponent<CardInPanel>().SetDataFromCard(card);
            Instantiate(g, this.transform);
        }
    }

}
