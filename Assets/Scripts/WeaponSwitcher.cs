using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    int numberOfWeapons;
    int numberOfBuyable;



    void Start()
    {
        SetWeaponActive();
        numberOfBuyable = 0;
        numberOfWeapons = (transform.childCount - 1) - numberOfBuyable;
        
    }


    void Update()
    {
        int previosWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previosWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currentWeapon>= numberOfWeapons )  //numberOfWeapons = transform.childCount - 1;
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = numberOfWeapons; //numberOfWeapons = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }

    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        
        foreach(Transform weapon in transform)
        {
     
             if (weaponIndex == currentWeapon )
            {
                
                weapon.gameObject.SetActive(true);
                
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }


    public void AddWeaponAfterBuying(){
        numberOfBuyable--;
        numberOfWeapons++;
    }
    
}
