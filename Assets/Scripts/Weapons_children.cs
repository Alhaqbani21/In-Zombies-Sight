using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_children : MonoBehaviour
{
    public List<Transform> children;

    bool weaponSwitchCalled;
    int current_index = 4;
    int new_index = 3;

    // Start is called before the first frame update
    void Start()
    {
        weaponSwitchCalled = false;
        List<Transform> children = GetChildren(transform);
  
    }

    List<Transform> GetChildren(Transform parent)
    {
         List<Transform> children = new List<Transform>();

         foreach(Transform child in parent)
         {
            children.Add(child);
         }
         return children;
         
    }

    public void switchWeaponIndex(int current, int newOne)
    {
        weaponSwitchCalled = true;
        current_index = current;
        new_index = newOne;
        //children[current_index].transform.SetSiblingIndex(new_index);
    }


    private void Update() {

        if(weaponSwitchCalled == true){
            List<Transform> children = GetChildren(transform);
            children[current_index].transform.SetSiblingIndex(new_index);
            weaponSwitchCalled = false;
        }   
        
    }
 
}
