using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public PixelSlider masterSlider;
    public PixelSlider sfxSlider;
    public PixelSlider musicSlider;
    public DisplayModeSelector displayMode;
    public void ExitToMainMenu()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);

        if (displayMode != null)
        {
            PlayerPrefs.SetInt("Fullscreen", displayMode.IsFullscreen ? 1 : 0);
        }
        
        PlayerPrefs.Save();

        SceneManager.LoadScene("MainMenu");
    }
}
