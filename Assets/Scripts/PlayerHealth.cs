using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
     float Money = 500f;

    [SerializeField] TextMeshProUGUI healthText; 

    [SerializeField] TextMeshProUGUI MoneyText; 


    public bool playerIsDead= false;

    // Start is called before the first frame update
    void Start()
    {
        playerIsDead= false;
        UpdateHealthText();
        UpdateMoneyText();

    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        UpdateHealthText(); // Update the health text after taking damage
        
        if (hitPoints <= 0)
        {
            playerIsDead= true;
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    void UpdateHealthText()
    {
        healthText.text =   hitPoints.ToString(); // Update the text with the current health amount
    }



   public void AddMoney(float addMoney)
    {
        Money += addMoney;
        UpdateMoneyText(); // Update the Money text 
    }




        void UpdateMoneyText()
    {
        MoneyText.text =  Money.ToString(); // Update the text with the current Money amount
    }
}
