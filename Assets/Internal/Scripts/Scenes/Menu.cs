using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void FinalScene()
    {
        SceneManager.LoadScene("Final");
    }
}
