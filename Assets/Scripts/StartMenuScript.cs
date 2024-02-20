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
        playButton.onClick.AddListener(PlayOnClick);
        settingButton.onClick.AddListener(SettingOnClick);
        quitButton.onClick.AddListener(QuitOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayOnClick()
    {
        SceneManager.LoadScene(1);
    }

    void SettingOnClick()
    {
        SceneManager.LoadScene(2);
    }

    void QuitOnClick()
    {
        Application.Quit();
    }
}
