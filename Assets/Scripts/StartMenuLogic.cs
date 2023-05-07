using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuLogic : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene("Zombie Game");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void OptionButton()
    {
        Debug.Log("Options...");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void Start(){
        SceneManager.UnloadScene(1);
        Time.timeScale = 0;
        WeaponSwitcher weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        if (weaponSwitcher != null)
        {
            weaponSwitcher.enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
