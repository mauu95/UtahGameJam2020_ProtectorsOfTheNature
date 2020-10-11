using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneScript : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToGameMenu()
    {
        SceneManager.LoadScene("IntroMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}