using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI healthText; 

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthText();
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        UpdateHealthText(); // Update the health text after taking damage

        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    void UpdateHealthText()
    {
        healthText.text =   hitPoints.ToString(); // Update the text with the current health amount
    }
}
