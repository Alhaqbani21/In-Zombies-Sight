using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyWeapon : MonoBehaviour
{
    PlayerHealth target; // will be used for player money
    Weapons_children weaponsAllChildren;
    WeaponSwitcher switcher;
    [SerializeField] TMP_Text User_text;
    [SerializeField] TMP_Text NoMoney;
    [SerializeField] float Cost;


    private AudioSource soundSource;
    bool bought;

    
    int numberofbought;


    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        switcher = FindObjectOfType<WeaponSwitcher>();
        weaponsAllChildren = FindObjectOfType<Weapons_children>();
        User_text.enabled = false;
        NoMoney.enabled = false;
        bought = false;
        soundSource= GetComponent<AudioSource>();
         numberofbought = 0;

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

        if(this.gameObject.name == "M1A1ToBuy")
        {
            Debug.Log("in buy");
            weaponsAllChildren.switchWeaponIndex(4 + numberofbought,3);
            numberofbought++;
        }
        else  if(this.gameObject.name == "MP7ToBuy")
        {
            Debug.Log("in buy");
            weaponsAllChildren.switchWeaponIndex(3 + numberofbought,3);
            numberofbought++;
        }

        
    }

}
