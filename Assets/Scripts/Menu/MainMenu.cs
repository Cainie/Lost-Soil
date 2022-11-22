namespace Menu
{
    using System.IO;
    using Misc;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class MainMenu : MonoBehaviour
    {
        private const string FilePathEnding = "/player.save";
        
        public void PlayGame()
        {
            GlobalVariables.isNewGame = true;
            SceneManager.LoadScene("DialogueScene");
        }
        
        public void LoadGame()
        {
            if (!File.Exists(Application.persistentDataPath + FilePathEnding)) {return;}
            GlobalVariables.isNewGame = false;
            SceneManager.LoadScene("ResourcesMechanicTestScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
