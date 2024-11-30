using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("Testing");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void winGame()
    {
        SceneManager.LoadScene("WinGame");
    }

    public void loseGame()
    {
        SceneManager.LoadScene("LoseGame");
    }
}
