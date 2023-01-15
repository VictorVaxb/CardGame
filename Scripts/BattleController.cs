using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleController : MonoBehaviour
{
    private Deck deck;
    private DiscardPile discardPile;
    private Hand hand;
    public TextMeshProUGUI handSizeText;
    private ActiveCard activeCard;
    public int cardsDrawedAtStart = 5;
    private Player player;
    private Enemy enemy;
    [SerializeField] private int activeCardId = 0;
    private CardActions cardActions;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
        enemy = GameObject.FindGameObjectsWithTag("Enemy")[0].GetComponent<Enemy>();
        hand = GameObject.FindGameObjectsWithTag("Hand")[0].GetComponent<Hand>();
        cardActions = GameObject.FindGameObjectsWithTag("CardActions")[0].GetComponent<CardActions>();
        deck = GameObject.FindGameObjectsWithTag("Deck")[0].GetComponent<Deck>();
        discardPile = GameObject.FindGameObjectsWithTag("DiscardPile")[0].GetComponent<DiscardPile>();
        InitialDraw();
    }

    void Update()
    {
        handSizeText.text = hand.handCards.Count.ToString();
    }

    public void Draw() {
        if(deck.deck.Count > 0){
            Card drawedCard = deck.DrawCardFromDeck();
            hand.AddCardToHand(drawedCard);
        }
    }

    public void InitialDraw() {
        for(int x = 0;x<cardsDrawedAtStart;x++){
            if(deck.deck.Count > 0){
                Card drawedCard = deck.DrawCardFromDeck();
                hand.AddCardToHand(drawedCard);
            }   
        }
    }

    public void SetActiveCard(int cardId) {
        //Find card by Id
        activeCardId = cardId;
        //Card cardSelected = hand.GetCardById(cardId);
        //activeCard.SetActive(cardSelected);
    }

    public void PlayActiveCard(){
        //Debug.Log("Playing " + activeCardId);
        
        Card cardToPlay = hand.GetCardById(activeCardId);
        if(player.GetActionPoints() >= cardToPlay.castingCost){
            player.removeActionPoints(cardToPlay.castingCost);
            cardActions.ExecuteCard(cardToPlay);
            hand.RemoveCardById(activeCardId);
            discardPile.AddCardToDiscardPile(cardToPlay);
        }else{
            Debug.Log("TODO: no tienes action points");
        }
    }

    public void EndTurn(){
        enemy.StartNewTurn();
        StartNewTurn();
    }

    public void StartNewTurn(){
        player.startNewTurn();
        Draw();
    }

}
