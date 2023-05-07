using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuLogic : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene("Zombie Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
