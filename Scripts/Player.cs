using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public string playerName;
    public int startingLife = 20;
    private int life = 0;
    public int startingShield = 0;
    private int shield = 0;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI actionPointsText;
    public int startingActionPoints = 3;
    public int actionPoints = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        life = startingLife;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = life.ToString();
        shieldText.text = shield.ToString();
        actionPointsText.text = actionPoints.ToString() + "/" + startingActionPoints.ToString();
    }

    public int ReceivePiercingDamage(int damage){
        life = life - damage;
        return life;
    }

    public void GainLife(int addedLife){
        life = life + addedLife;
    }

    public int ReceiveNormalDamage(int damage){
        if(shield > 0){
            if(shield >= damage){
                shield = shield - damage;
            }else{
                int difference = damage - shield;
                shield = 0;
                life = life - difference;
            }
        }else{
            life = life - damage;
        }
        return life;
    }

    public void GainShield(int addedShield){
        shield = shield + addedShield;
        Debug.Log("new shield " + shield);
    }

    public void startNewTurn(){
        shield = startingShield;
        actionPoints = startingActionPoints;
    }

    public int GetActionPoints(){
        return actionPoints;
    }

    public void removeActionPoints(int actionPointsToRemove){
        actionPoints = actionPoints - actionPointsToRemove;
    }

    public void addActionPoints(int actionPointsToAdd){
        actionPoints = actionPoints + actionPointsToAdd;
    }
}
