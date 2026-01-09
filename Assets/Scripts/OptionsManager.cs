using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public PixelSlider masterSlider;
    public PixelSlider sfxSlider;
    public PixelSlider musicSlider;

    public DisplayModeSelector displayMode;

    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");

        if (PlayerPrefs.HasKey("SFXVolume"))
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        if (PlayerPrefs.HasKey("MusicVolume"))
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        if (displayMode != null && PlayerPrefs.HasKey("Fullscreen"))
        {
            bool fullscreen = PlayerPrefs.GetInt("Fullscreen") == 1;
            displayMode.ApplyFullscreen(fullscreen);
        }

    }
}
