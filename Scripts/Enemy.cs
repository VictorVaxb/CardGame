using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public string enemyName = "";
    public string enemyType = "";
    public int startingLife = 20;
    private int life = 0;
    public int startingShield = 0;
    private int shield = 0;
    public int numberOfActions = 1;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI shieldText;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        life = startingLife;
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = life.ToString();
        shieldText.text = shield.ToString();
    }

    public void StartNewTurn(){
        player.ReceiveNormalDamage(3);
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
}
