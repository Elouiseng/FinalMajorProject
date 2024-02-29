using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMapScript : MonoBehaviour
{
    public Button openPopUpButton, closePopUpButton, settingsButton, quitButton;
    public Button level1Button, level2Button, level3Button, level4Button, level5Button;
    public GameObject rightPopUp;
    public AudioClip buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        openPopUpButton.onClick.AddListener(OpenRightPopUp);
        closePopUpButton.onClick.AddListener(CloseRightPopUp);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);

        rightPopUp.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenRightPopUp()
    {
        openPopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        rightPopUp.SetActive(true);
    }

    void CloseRightPopUp()
    {
        closePopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound); //BUG: This button doesn't play sound!!!!!!!!!!!!!!!!!!!!!!!
        Debug.Log("plays sound");
        StartCoroutine(WaitForSound());
        rightPopUp.SetActive(false);
    }

    void OpenSettings()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("previousScene", currentScene);
        settingsButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("SettingsScene");
    }
    void QuitGame()
    {
        quitButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        Application.Quit();
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
