using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingsScript : MonoBehaviour
{
    public Button graphicsButton, audioButton, otherButton;
    public GameObject graphicsPanel, audioPanel, otherPanel;
    public Button closeSettingsButton;
    public TMP_Dropdown screenModeDropdown, resolutionDropdown;

    private int nextSceneToOpen;
    private Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("previousScene"))
        {
            PlayerPrefs.SetInt("previousScene", 0);
        }

        closeSettingsButton.onClick.AddListener(CloseSettings);
        graphicsButton.onClick.AddListener(ShowGraphicsSettings);
        audioButton.onClick.AddListener(ShowAudioSettings);
        otherButton.onClick.AddListener(ShowOtherSettings);
        screenModeDropdown.onValueChanged.AddListener(value => OnScreenModeChanged(value));
        resolutionDropdown.onValueChanged.AddListener(value => OnResolutionChanged(value));

        graphicsPanel.SetActive(true);
        audioPanel.SetActive(false);
        otherPanel.SetActive(false);

        resolutions = Screen.resolutions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseSettings()
    {
       
        nextSceneToOpen = PlayerPrefs.GetInt("previousScene");
        SceneManager.LoadScene(nextSceneToOpen);
    }

    void ShowGraphicsSettings()
    {
        if(!graphicsPanel.activeSelf)
        {
            graphicsPanel.SetActive(true);
            audioPanel.SetActive(false);
            otherPanel.SetActive(false);
        }

    }

    void ShowAudioSettings()
    {
        if (!audioPanel.activeSelf)
        {
            graphicsPanel.SetActive(false);
            audioPanel.SetActive(true);
            otherPanel.SetActive(false);
        }
    }

    void ShowOtherSettings()
    {
        if (!otherPanel.activeSelf)
        {
            graphicsPanel.SetActive(false);
            audioPanel.SetActive(false);
            otherPanel.SetActive(true);
        }
    }
    
    /// <To-Do>
    /// Showing the option that was last selected when changing the scene and going back to settings.
    /// When going into settings shown option is Fullscreen and not the option that it actually is.
    /// 
    void OnScreenModeChanged(int value)
    {
        int selectedOption = screenModeDropdown.value;

        switch (selectedOption)
        {
            case 0: // Fullscreen
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                PlayerPrefs.SetInt("ScreenMode", 0);
                Debug.Log("Changed to ExclusiveFullScreen" + PlayerPrefs.GetInt("ScreenMode"));
                screenModeDropdown.RefreshShownValue();
                break;

            case 1: // Windowed
                Screen.fullScreenMode = FullScreenMode.Windowed;
                PlayerPrefs.SetInt("ScreenMode", 1);
                Debug.Log("Changed to Windowed" + PlayerPrefs.GetInt("ScreenMode"));
                screenModeDropdown.RefreshShownValue();

                break;

            case 2: // Windowed Fullscreen
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                PlayerPrefs.SetInt("ScreenMode", 2);
                Debug.Log("Changed to FullScreenWindow" + PlayerPrefs.GetInt("ScreenMode"));
                screenModeDropdown.RefreshShownValue();

                break;

            default:
                Debug.LogError("Invalid screen mode option selected");
                PlayerPrefs.DeleteKey("ScreenMode");
                break;
        }
    }

    void OnResolutionChanged(int value)
    {
        for
    }
}
