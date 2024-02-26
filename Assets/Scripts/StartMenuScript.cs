using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenuScript : MonoBehaviour
{
    public Button playButton, settingButton, quitButton;



    // Start is called before the first frame update
    void Start()
    {

        playButton.onClick.AddListener(StartGame);
        settingButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);

        if (!PlayerPrefs.HasKey("ScreenMode"))
        {
            PlayerPrefs.SetInt("ScreenMode", 0);
        }
        ScreenMode();
        Debug.Log("Changed to " + PlayerPrefs.GetInt("ScreenMode"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        SceneManager.LoadScene("LevelMapScene");
    }

    void OpenSettings()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("previousScene", currentScene);
        SceneManager.LoadScene("SettingsScene");
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void ScreenMode()
    {
        if (PlayerPrefs.GetInt("ScreenMode") == 0)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else if (PlayerPrefs.GetInt("ScreenMode") == 1)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else if (PlayerPrefs.GetInt("ScreenMode") == 1)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
    }
}
