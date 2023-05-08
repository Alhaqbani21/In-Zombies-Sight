using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyWeapon : MonoBehaviour
{
    PlayerHealth target; // will be used for player money
    WeaponSwitcher switcher;
    [SerializeField] TMP_Text User_text;
    [SerializeField] TMP_Text NoMoney;
    [SerializeField] float Cost;


    private AudioSource soundSource;
    bool bought;




    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        switcher = FindObjectOfType<WeaponSwitcher>();
        User_text.enabled = false;
        NoMoney.enabled = false;
        bought = false;
        soundSource= GetComponent<AudioSource>();

    }

 

    private void OnTriggerEnter(Collider other) 
    {
      
        if(other.gameObject.tag == "Player" && !bought)
        {
            User_text.enabled = true;

        }
    }


    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player" && !bought)
        {
            if (Input.GetKeyDown(KeyCode.F)) 
            {
                if(target.checkMoney(Cost))// check if we have enough money
                {
                    
                    soundSource.Play();
                    target.ReduceMoney(Cost); // subtract money
                    User_text.enabled = false;

                    bought = true; // change perk to true once obtained
                    addWeapon();
                }
                else
                {
                    User_text.enabled = false;
                    NoMoney.enabled = true;


                }
            }          

        }
    }

    
    private void OnTriggerExit(Collider other) 
    {
    

     if(other.gameObject.tag == "Player")
        {
            User_text.enabled = false;
            NoMoney.enabled = false;


        }
    }

    void addWeapon()
    {
        switcher.AddWeaponAfterBuying();
        
    }

}
