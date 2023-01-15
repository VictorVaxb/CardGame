using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardInPanelUi : MonoBehaviour
{
    public TextMeshProUGUI castingCostText;
    [SerializeField] private int cardCastingCost = 0;
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI cardDescriptionText;
    [SerializeField] private int cardId = 0;
    private BattleController controller;
    Animator animator;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<BattleController>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
    }

    public void SetDataFromCard(Card newCard){
        cardId = newCard.cardId;
        castingCostText.text = newCard.castingCost.ToString();
        cardNameText.text = newCard.cardName;
        cardDescriptionText.text = newCard.description;
        cardCastingCost = newCard.castingCost;
    }

    public void SetActiveCard(){ 
        controller.SetActiveCard(cardId);
    }

    public void HoverCard(){
        animator.Play("hover");
        controller.SetActiveCard(cardId);
    }

    public void HoverCardEnd(){
        animator.Play("notHover");
    }

    public void OnClick(){
        int remainingActionsPoints = player.GetActionPoints();
        Debug.Log(remainingActionsPoints + " >= " + cardCastingCost);
        if(remainingActionsPoints >= cardCastingCost){
            animator.Play("disapear");
            controller.PlayActiveCard();
        }
    }
}
