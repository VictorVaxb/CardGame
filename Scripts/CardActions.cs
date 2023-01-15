using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardActions : MonoBehaviour
{
    private Player player;
    private BattleController controller;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
        controller = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<BattleController>();
    }

    public void ExecuteCard(Card card){
        // card,damage to the enemy
        if(card.heal > 0){
            player.GainLife(card.heal);
        }
        if(card.protect > 0){
            player.GainShield(card.protect);
        }
        if(card.draw > 0){
            for(int x = 0;x<card.draw;x++){
                controller.Draw();
            }
        }
    }
}
