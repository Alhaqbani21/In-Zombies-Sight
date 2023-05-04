using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandler : MonoBehaviour
{
    [SerializeField] Canvas WinCanvas;
    //int keysCollected;
    // Start is called before the first frame update
    void Start()
    {
        WinCanvas.enabled = false;
        //keysCollected = GetComponent<KeyCollectables>().getKeysCollected();
    }

    // Update is called once per frame
    public void HandleWin()
    {
        WinCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Destroy(gameObject);

    }
}
