using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingsScript : MonoBehaviour
{
    // Buttons for the different setting categories
    public Button graphicsButton, audioButton, otherButton;
    public GameObject graphicsPanel, audioPanel, otherPanel;
    public TMP_Dropdown screenModeDropdown, resolutionDropdown, refreshRateDropdown;

    public Button applyButton, closeSettingsButton;

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
        applyButton.onClick.AddListener();

        graphicsButton.onClick.AddListener(ShowGraphicsSettings);
        audioButton.onClick.AddListener(ShowAudioSettings);
        otherButton.onClick.AddListener(ShowOtherSettings);

        screenModeDropdown.onValueChanged.AddListener(value => OnScreenModeChanged(value));
        resolutionDropdown.onValueChanged.AddListener(value => OnResolutionChanged(value));
        refreshRateDropdown.onValueChanged.AddListener(value => OnResolutionChanged(value));

        graphicsPanel.SetActive(true);
        audioPanel.SetActive(false);
        otherPanel.SetActive(false);

        resolutions = Screen.resolutions;
        PopulateResolutionDropdown();
    }

    #region show setting category
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
    #endregion

    /// <To-Do>
    /// Showing the option that was last selected when changing the scene and going back to settings.
    /// When going into settings shown option is Fullscreen and not the option that it actually is.
    ///
    #region display mode

    /// <summary>
    /// Gets the screenModeDropdown.Option and makes the game FullScreen, Windowed or Windowed Fullscreen mode.
    /// </summary>
    /// <param name="value"></param>
    void OnScreenModeChanged(int value)
    {
        int selectedOption = screenModeDropdown.value;

        switch (selectedOption)
        {
            case 0: // Fullscreen
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                PlayerPrefs.SetInt("ScreenMode", 0);
                Debug.Log("Changed to ExclusiveFullScreen" + PlayerPrefs.GetInt("ScreenMode"));
                break;

            case 1: // Windowed
                Screen.fullScreenMode = FullScreenMode.Windowed;
                PlayerPrefs.SetInt("ScreenMode", 1);
                Debug.Log("Changed to Windowed" + PlayerPrefs.GetInt("ScreenMode"));
                break;

            case 2: // Windowed Fullscreen
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                PlayerPrefs.SetInt("ScreenMode", 2);
                Debug.Log("Changed to FullScreenWindow" + PlayerPrefs.GetInt("ScreenMode"));
                break;

            default:
                Debug.LogError("Invalid screen mode option selected");
                PlayerPrefs.DeleteKey("ScreenMode");
                break;
        }
        screenModeDropdown.RefreshShownValue();
    }
    #endregion

    #region display resolution 
    void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> resolutionOptions = new List<TMP_Dropdown.OptionData>();

        foreach (var res in resolutions)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData($"{res.width} x {res.height} {res.refreshRateRatio}Hz");
            resolutionOptions.Add(optionData);
        }

        resolutionDropdown.AddOptions(resolutionOptions);
    }
    void OnResolutionChanged(int value)
    {
        Debug.Log($"Resolution changed to {resolutions[value].width} x {resolutions[value].height} {resolutions[value].refreshRateRatio}Hz");
        ApplySettings(resolutions[value].width, resolutions[value].height);
    }
    #endregion

    void ApplySettings(int width, int height)
    {

        if (Screen.fullScreenMode != FullScreenMode.ExclusiveFullScreen)
        {
            Screen.SetResolution(width, height, false);
        }
        
    }

    /// <summary>
    /// Loads the scene that was open before settings, with getting the information from PlayerPrefs("previousScene")
    /// </summary>
    void CloseSettings()
    {
        nextSceneToOpen = PlayerPrefs.GetInt("previousScene");
        SceneManager.LoadScene(nextSceneToOpen);
    }
}
