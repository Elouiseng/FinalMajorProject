using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class DisplaySettingsScript : MonoBehaviour
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
    public TMP_Dropdown screenModeDropdown, resolutionDropdown, refreshRateDropdown;
    public Button applyButton;
    public AudioClip buttonSound;

    private Resolution[] resolutions;
    private FullScreenMode selectedScreenMode;
    private Resolution selectedResolution;
    private RefreshRate selectedRefreshRate;

    // Start is called before the first frame update
    void Start()
    {
        applyButton.onClick.AddListener(ApplySettings);
        applyButton.interactable = false;

        screenModeDropdown.onValueChanged.AddListener(value => OnDropdownsChanged(value));
        resolutionDropdown.onValueChanged.AddListener(value => OnDropdownsChanged(value));
        refreshRateDropdown.onValueChanged.AddListener(value => OnDropdownsChanged(value));

        resolutions = Screen.resolutions;
        PopulateDropdownOptions();
    }

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
            Debug.Log(res.ToString());
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
        applyButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, selectedScreenMode, (int)selectedRefreshRate);
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
