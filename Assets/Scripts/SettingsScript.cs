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
    [SerializeField] Button graphicsButton, audioButton, otherButton, closeSettingsButton, creditsButton, deleteProgressButton, yesDeleteButton, noDeleteButton;
    [SerializeField] AudioClip buttonSound;

    private int nextSceneToOpen;
    private GameObject graphicsPanel, audioPanel, otherPanel, deleteRequestImage;
    // Start is called before the first frame update
    void Start()
    {
        graphicsPanel = GameObject.Find("GraphicsButton/GraphicsPanel");
        audioPanel = GameObject.Find("AudioButton/AudioPanel");
        otherPanel = GameObject.Find("OtherButton/OtherPanel");
        deleteRequestImage = GameObject.Find("DeleteProgressButton/DeleteRequestImage");

        closeSettingsButton.onClick.AddListener(CloseSettings);

        graphicsButton.onClick.AddListener(ShowGraphicsSettings);
        audioButton.onClick.AddListener(ShowAudioSettings);
        otherButton.onClick.AddListener(ShowOtherSettings);

        creditsButton.onClick.AddListener(OpenCreditsScene);
        deleteProgressButton.onClick.AddListener(OnDeleteProgressButtonClick);

        graphicsPanel.SetActive(true);
        audioPanel.SetActive(false);
        otherPanel.SetActive(false);
        deleteRequestImage.SetActive(false);
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

    void OpenCreditsScene()
    {
        creditsButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("CreditsScene");
    }

    void OnDeleteProgressButtonClick()
    {
        deleteProgressButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        yesDeleteButton.onClick.AddListener(OnYesButtonClick);
        noDeleteButton.onClick.AddListener(OnNoButtonClick);
        deleteRequestImage.SetActive(true);
    }
    void OnYesButtonClick()
    {
        yesDeleteButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("StartMenuScene");
    }

    void OnNoButtonClick()
    {
        noDeleteButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        yesDeleteButton.onClick.RemoveAllListeners();
        noDeleteButton.onClick.RemoveAllListeners();
        deleteRequestImage.SetActive(false);
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
