using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenuScript : MonoBehaviour
{
    public Button playButton, settingButton, quitButton;

    public Scene settingsScene;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        settingButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);
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
        SettingsScript.SetPreviousSceneIndex(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(settingsScene.buildIndex);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
