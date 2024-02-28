using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SettingsScript : MonoBehaviour
{
    public enum RefreshRate
    {
        Thirty = 30,
        Sixty = 60, // Default refresh rate
        OneTwenty = 120,
        OneFortyFour = 144,
        Unlimited = -1
    }   

    // Buttons for the different setting categories
    public Button graphicsButton, audioButton, otherButton;
    public GameObject graphicsPanel, audioPanel, otherPanel;
    public TMP_Dropdown screenModeDropdown, resolutionDropdown, refreshRateDropdown;

    public Button applyButton, closeSettingsButton;

    private int nextSceneToOpen;

    private Resolution[] resolutions;

    private FullScreenMode selectedScreenMode;
    private Resolution selectedResolution;
    private RefreshRate selectedRefreshRate;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("previousScene"))
        {
            PlayerPrefs.SetInt("previousScene", 0);
        }

        closeSettingsButton.onClick.AddListener(CloseSettings);
        applyButton.onClick.AddListener(ApplySettings);
        applyButton.interactable = false;

        graphicsButton.onClick.AddListener(ShowGraphicsSettings);
        audioButton.onClick.AddListener(ShowAudioSettings);
        otherButton.onClick.AddListener(ShowOtherSettings);

        screenModeDropdown.onValueChanged.AddListener(value => OnDropdownsChanged(value));
        resolutionDropdown.onValueChanged.AddListener(value => OnDropdownsChanged(value));
        refreshRateDropdown.onValueChanged.AddListener(value => OnDropdownsChanged(value));

        graphicsPanel.SetActive(true);
        audioPanel.SetActive(false);
        otherPanel.SetActive(false);

        resolutions = Screen.resolutions;
        PopulateDropdownOptions();
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

    ///// <summary>
    ///// Gets the screenModeDropdown.Option and makes the game FullScreen, Windowed or Windowed Fullscreen mode.
    ///// </summary>
    ///// <param name="value"></param>
    //void OnScreenModeChanged(int value)
    //{
    //    int selectedOption = screenModeDropdown.value;

    //    switch (selectedOption)
    //    {
    //        case 0: // Fullscreen
    //            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    //            PlayerPrefs.SetInt("ScreenMode", 0);
    //            Debug.Log("Changed to ExclusiveFullScreen" + PlayerPrefs.GetInt("ScreenMode"));
    //            break;

    //        case 1: // Windowed
    //            Screen.fullScreenMode = FullScreenMode.Windowed;
    //            PlayerPrefs.SetInt("ScreenMode", 1);
    //            Debug.Log("Changed to Windowed" + PlayerPrefs.GetInt("ScreenMode"));
    //            break;

    //        case 2: // Windowed Fullscreen
    //            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    //            PlayerPrefs.SetInt("ScreenMode", 2);
    //            Debug.Log("Changed to FullScreenWindow" + PlayerPrefs.GetInt("ScreenMode"));
    //            break;

    //        default:
    //            Debug.LogError("Invalid screen mode option selected");
    //            PlayerPrefs.DeleteKey("ScreenMode");
    //            break;
    //    }
    //    screenModeDropdown.RefreshShownValue();
    //}
    #endregion

    #region display resolution 
    void PopulateDropdownOptions()
    {
        screenModeDropdown.ClearOptions();
        resolutionDropdown.ClearOptions();
        refreshRateDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> screenModeOptions = new List<TMP_Dropdown.OptionData>();
        List<TMP_Dropdown.OptionData> resolutionOptions = new List<TMP_Dropdown.OptionData>();
        List<TMP_Dropdown.OptionData> refreshRateOptions = new List<TMP_Dropdown.OptionData>();

        screenModeOptions.Add(new TMP_Dropdown.OptionData(FullScreenMode.ExclusiveFullScreen.ToString()));
        screenModeOptions.Add(new TMP_Dropdown.OptionData(FullScreenMode.Windowed.ToString()));
        screenModeOptions.Add(new TMP_Dropdown.OptionData(FullScreenMode.FullScreenWindow.ToString()));

        foreach (var res in resolutions)
        {
            TMP_Dropdown.OptionData resolutionOption = new TMP_Dropdown.OptionData($"{res.width} x {res.height}");
            resolutionOptions.Add(resolutionOption);
        }

        foreach (RefreshRate refreshRate in Enum.GetValues(typeof(RefreshRate)))
        {
            string refreshRateString;

            if (refreshRate == RefreshRate.Unlimited)
            {
                refreshRateString = "Unlimited";
            }
            else
            {
                refreshRateString = ((int)refreshRate).ToString();
            }

            refreshRateOptions.Add(new TMP_Dropdown.OptionData(refreshRateString));
        }

        screenModeDropdown.AddOptions(screenModeOptions);
        resolutionDropdown.AddOptions(resolutionOptions);
        refreshRateDropdown.AddOptions(refreshRateOptions);
    }
    void OnDropdownsChanged(int value)
    {
        selectedScreenMode = (FullScreenMode)Enum.Parse(typeof(FullScreenMode), screenModeDropdown.options[screenModeDropdown.value].text);
        selectedResolution = resolutions[resolutionDropdown.value];
        if (Enum.TryParse(refreshRateDropdown.options[refreshRateDropdown.value].text, out RefreshRate parsedRefreshRate))
        {
            selectedRefreshRate = parsedRefreshRate;
        }
        else
        {
            selectedRefreshRate = RefreshRate.Sixty; // Default refresh rate
        }

        applyButton.interactable = true;

        screenModeDropdown.RefreshShownValue();
        resolutionDropdown.RefreshShownValue();
        refreshRateDropdown.RefreshShownValue();
    }
    #endregion

    void ApplySettings()
    {
        Debug.Log("Setting the values to: " + selectedResolution.width.ToString() + "x" + selectedResolution.height.ToString() + ", " + selectedScreenMode.ToString() + ", " + selectedRefreshRate.ToString());
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, selectedScreenMode, (int)selectedRefreshRate);
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
