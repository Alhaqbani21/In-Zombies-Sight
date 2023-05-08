using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGateDoor : MonoBehaviour
{
    [SerializeField] TMP_Text needKeysText;

    void Start()
    {
        needKeysText.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (KeyCollectables.keysCollected != 3)
            {
                // show that he still needs x more keys
                needKeysText.enabled = true;
            }
            else if(KeyCollectables.keysCollected == 3) 
            {
                FindObjectOfType<WinHandler>().HandleWin();
                //KeyCollectables.keysCollected = 0;
                needKeysText.enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        needKeysText.enabled = false;

    }

}
