using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardInPanel : MonoBehaviour
{
    public TextMeshProUGUI castingCostText;
    public TextMeshProUGUI cardNameText;
    [SerializeField] private int cardId = 0;
    private BattleController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<BattleController>();
    }

    public void SetDataFromCard(Card newCard){
        cardId = newCard.cardId;
        castingCostText.text = newCard.castingCost.ToString();
        cardNameText.text = newCard.cardName;
    }

    public void SetActiveCard(){ 
        controller.SetActiveCard(cardId);
    }

}
