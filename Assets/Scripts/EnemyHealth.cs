using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;

    PlayerHealth target; // will be used for player money

     void Start() 
     {
        
    target = FindObjectOfType<PlayerHealth>();

     }

    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage (float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;

        if(!isDead)
        {
        target.AddMoney(75); // add money to the player on every hit
        }

        if (hitPoints <= 0)
        {
            Die();
            //Destroy(gameObject);

        }
   

    }
    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
    
}
