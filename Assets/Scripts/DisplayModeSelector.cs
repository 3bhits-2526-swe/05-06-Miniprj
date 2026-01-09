using UnityEngine;
using UnityEngine.UI;

public class DisplayModeSelector : MonoBehaviour
{
    public Button fullscreenButton;
    public Button windowedButton;

    public Image fullscreenImage;
    public Image windowedImage;

    public Color normalColor = Color.white;
    public Color selectedColor = new Color(0.7f, 0.7f, 0.7f, 1f);

    public bool IsFullscreen { get; private set; }

    void Start()
    {
        fullscreenButton.onClick.AddListener(SetFullscreen);
        windowedButton.onClick.AddListener(SetWindowed);
    }

    public void SetFullscreen()
    {
        ApplyFullscreen(true);
    }

    public void SetWindowed()
    {
        ApplyFullscreen(false);
    }

    public void ApplyFullscreen(bool fullscreen)
    {
        IsFullscreen = fullscreen;

        Screen.fullScreenMode = fullscreen
            ? FullScreenMode.FullScreenWindow
            : FullScreenMode.Windowed;

        Screen.fullScreen = fullscreen;

        fullscreenImage.color = fullscreen ? selectedColor : normalColor;
        windowedImage.color   = fullscreen ? normalColor : selectedColor;
    }
}
