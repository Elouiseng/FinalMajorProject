using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenuScript : MonoBehaviour
{
    public Button playButton, settingButton, quitButton, closeSettingsButton;
    public GameObject settingsScreen; 

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        settingButton.onClick.AddListener(OpenSettings);
        closeSettingsButton.onClick.AddListener(CloseSettings);
        quitButton.onClick.AddListener(QuitGame);

        settingsScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void OpenSettings()
    {
        settingsScreen.SetActive(true);
    }

    void CloseSettings()
    {
        settingsScreen.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
