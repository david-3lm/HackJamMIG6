using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void selectScene(int id)
    {
        switch (id)
        {
            case 0:
                SceneManager.LoadScene("Menu");
                break;
            case 1:
                SceneManager.LoadScene("Testing_Juego");
                break;
            case 2:
                SceneManager.LoadScene("WinGame");
                break;
            case 3:
                SceneManager.LoadScene("LoseGame0");
                break;
            case 4:
                SceneManager.LoadScene("LoseGame1");
                break;
            case 5:
                SceneManager.LoadScene("LoseGame2");
                break;
            case 6:
                SceneManager.LoadScene("LoseGame3");
                break;
            case 7:
                SceneManager.LoadScene("LoseGame4");
                break;
            case 8:
                Application.Quit();
                break;
        }
    }
}
