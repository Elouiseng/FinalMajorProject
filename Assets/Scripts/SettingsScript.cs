using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Button graphicsButton, audioButton, otherButton;
    public GameObject graphicsPanel, audioPanel, otherPanel;
    public Button closeSettingsButton;

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
}
