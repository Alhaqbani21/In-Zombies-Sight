using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PickGunItems : MonoBehaviour
{

    [SerializeField] TMP_Text User_text;
    [SerializeField] Image itemImage;

    private AudioSource soundSource;
     BuyWeapon myparts;
     bool parts_collected;
     

void Start()
    {
        //target = FindObjectOfType<PlayerHealth>();
        User_text.enabled = false;
        itemImage.enabled = false;
        soundSource = GetComponent<AudioSource>();
        myparts = GetComponent<BuyWeapon>();
        parts_collected=false;

    }


    private void OnTriggerEnter(Collider other) 
    {
      
        if(other.gameObject.tag == "Player" && (parts_collected == false))
        {
            User_text.enabled = true;

        }
    }


    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player" && (parts_collected == false))
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                myparts.addWeaponPart();
                itemImage.enabled = true;
                itemImage.enabled = true;
                parts_collected=true;


            }
                     

        }
    }

    
    private void OnTriggerExit(Collider other) 
    {
    

     if(other.gameObject.tag == "Player" && (parts_collected == false))
        {
            User_text.enabled = false;
        }
    }

}
