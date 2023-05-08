using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkSystem : MonoBehaviour
{



    PlayerHealth target; // will be used for player money
    UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController Mytarget;
    [SerializeField] TMP_Text User_text;
    [SerializeField] TMP_Text NoMoney;
    [SerializeField] Image perkImage;
    [SerializeField] private float movementSpeed;

    [SerializeField] float Cost;


    private AudioSource soundSource;
    bool bought;




    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        Mytarget = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
        movementSpeed = Mytarget.movementSettings.ForwardSpeed;
        Debug.Log(movementSpeed);
        User_text.enabled = false;
        NoMoney.enabled = false;
        bought = false;
        perkImage.enabled = false;
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
                    perkImage.enabled = true;
                    perkType();
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

    void perkType()
    {
        if(this.gameObject.tag == "Blitz")
        {
            target.AddHealthPerk();
        }
        else if(this.gameObject.tag == "Stamina")
        {
            Mytarget.movementSettings.ForwardSpeed += 2f;
            Mytarget.movementSettings.BackwardSpeed+= 2f;
            Mytarget.movementSettings.StrafeSpeed += 2f;
        }
    }

}
