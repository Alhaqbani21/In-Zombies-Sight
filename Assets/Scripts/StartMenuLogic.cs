using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuLogic : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Zombie Game");
    }
    public void OptionButton()
    {
        Debug.Log("Options...");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
