using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{    
    public GameObject victoryScreen;
      
    public void Victory()
    {
        victoryScreen.SetActive(true);             
    }

    public void LoadMenu()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
