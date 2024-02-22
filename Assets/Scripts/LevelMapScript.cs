using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMapScript : MonoBehaviour
{
    public Button openPopUpButton, closePopUpButton, settingsButton, quitButton;
    public Button level1Button, level2Button;

    // Start is called before the first frame update
    void Start()
    {
        openPopUpButton.onClick.AddListener(OpenRightPopUp);
        closePopUpButton.onClick.AddListener(CloseRightPopUp);
        settingsButton.onClick.AddListener(SettingOnClick);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SettingOnClick()
    {
        SceneManager.LoadScene(2);
    }
}
