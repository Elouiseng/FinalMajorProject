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
    [SerializeField] TMP_Dropdown screenModeDropdown, resolutionDropdown;
    [SerializeField] Button applyButton;
    [SerializeField] AudioClip buttonSound;

    private Resolution[] resolutions;
    private FullScreenMode selectedScreenMode;
    private Resolution selectedResolution;

    private void Awake()
    {
        applyButton.onClick.AddListener(ApplySettings);
        applyButton.interactable = false;

        screenModeDropdown.onValueChanged.AddListener(value => OnDropdownsChanged(value));
        resolutionDropdown.onValueChanged.AddListener(value => OnDropdownsChanged(value));

    }

    // Start is called before the first frame update
    void Start()
    {
        screenModeDropdown.value = PlayerPrefs.GetInt("DisplayModeOption");
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionOption");
        PopulateDropdownOptions();        
        
        screenModeDropdown.RefreshShownValue();
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
        if (selectedScreenMode.Equals(FullScreenMode.ExclusiveFullScreen))
        {
            resolutionDropdown.interactable = false;
        } 
        else
        {
            resolutionDropdown.interactable = true;
        }
    }

    #region display resolution 
    void PopulateDropdownOptions()
    {
        resolutions = Screen.resolutions;

        screenModeDropdown.ClearOptions();
        resolutionDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> screenModeOptions = new List<TMP_Dropdown.OptionData>();
        List<TMP_Dropdown.OptionData> resolutionOptions = new List<TMP_Dropdown.OptionData>();

        screenModeOptions.Add(new TMP_Dropdown.OptionData(FullScreenMode.ExclusiveFullScreen.ToString()));
        screenModeOptions.Add(new TMP_Dropdown.OptionData(FullScreenMode.Windowed.ToString()));
        screenModeOptions.Add(new TMP_Dropdown.OptionData(FullScreenMode.FullScreenWindow.ToString()));

        foreach (var res in resolutions)
        {
            TMP_Dropdown.OptionData resolutionOption = new TMP_Dropdown.OptionData($"{res.width} x {res.height} {res.refreshRateRatio}Hz");
            resolutionOptions.Add(resolutionOption);
        }

        screenModeDropdown.AddOptions(screenModeOptions);
        resolutionDropdown.AddOptions(resolutionOptions);
    }
    void OnDropdownsChanged(int value)
    {
        selectedScreenMode = (FullScreenMode)Enum.Parse(typeof(FullScreenMode), screenModeDropdown.options[screenModeDropdown.value].text);
        selectedResolution = resolutions[resolutionDropdown.value];

        applyButton.interactable = true;
    }
    #endregion

    void ApplySettings()
    {
        //Debug.Log("Setting the values to: " + selectedResolution.width.ToString() + "x" + selectedResolution.height.ToString() + ", " + selectedScreenMode.ToString());
        applyButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());

        PlayerPrefs.SetInt("DisplayModeOption", screenModeDropdown.value);
        PlayerPrefs.SetInt("ResolutionOption", resolutionDropdown.value);
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, selectedScreenMode);
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
