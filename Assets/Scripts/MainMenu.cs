using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Options()
    {
        Debug.Log("Options clicked");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
