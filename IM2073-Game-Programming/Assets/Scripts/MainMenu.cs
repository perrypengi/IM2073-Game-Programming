using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame"); //load main game scene
    }

    public void QuitGame()
    {
        Application.Quit(); //quit application
    }
}
