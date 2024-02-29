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
    // Buttons for the different setting categories
    public Button graphicsButton, audioButton, otherButton;
    public GameObject graphicsPanel, audioPanel, otherPanel;
    public Button closeSettingsButton;
    public AudioClip buttonSound;

    private int nextSceneToOpen;

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

        graphicsPanel.SetActive(true);
        audioPanel.SetActive(false);
        otherPanel.SetActive(false);
    }

    #region show setting category
    void ShowGraphicsSettings()
    {
        graphicsButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        if (!graphicsPanel.activeSelf)
        {
            graphicsPanel.SetActive(true);
            audioPanel.SetActive(false);
            otherPanel.SetActive(false);
        }
    }

    void ShowAudioSettings()
    {
        audioButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        if (!audioPanel.activeSelf)
        {
            graphicsPanel.SetActive(false);
            audioPanel.SetActive(true);
            otherPanel.SetActive(false);
        }
    }

    void ShowOtherSettings()
    {
        otherButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        if (!otherPanel.activeSelf)
        {
            graphicsPanel.SetActive(false);
            audioPanel.SetActive(false);
            otherPanel.SetActive(true);
        }
    }
    #endregion

    /// <summary>
    /// Loads the scene that was open before settings, with getting the information from PlayerPrefs("previousScene")
    /// </summary>
    void CloseSettings()
    {
        closeSettingsButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        nextSceneToOpen = PlayerPrefs.GetInt("previousScene");
        SceneManager.LoadScene(nextSceneToOpen);
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
