using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public static bool PlayerIsDead = false;

    public GameObject deathSceen;
      
    public void Death()
    {
        deathSceen.SetActive(true);
        Time.timeScale = 0f;
        PlayerIsDead = true;
    }

    public void LoadMenu()
    {
        PlayerIsDead = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
