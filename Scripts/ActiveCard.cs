using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActiveCard : MonoBehaviour
{
    public TextMeshProUGUI castingCost;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardDescription;
    private bool isActive = false;
    Animator animator;

    public void SetActive(Card activeCard){
        //Debug.Log("seteando data de " + activeCard);
        animator = GetComponent<Animator>();
        castingCost.text = activeCard.castingCost.ToString();
        cardName.text = activeCard.cardName;
        cardDescription.text = activeCard.description;
        isActive = true;
        animator.SetTrigger("isActive");
    }

    public void SetNonActive(){
        //Debug.Log("seteando data de " + activeCard);
        castingCost.text = "";
        cardName.text = "";
        cardDescription.text = "";
        isActive = false;
        animator.SetTrigger("isNonActive");
    }

    public bool getIsActive(){
        return isActive;
    }

}
