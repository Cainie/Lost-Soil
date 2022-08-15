namespace Menu
{
    using Misc;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class MainMenu : MonoBehaviour
    {
 
        public void PlayGame()
        {
            GlobalVariables.isNewGame = true;
            SceneManager.LoadScene("DialogueScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
