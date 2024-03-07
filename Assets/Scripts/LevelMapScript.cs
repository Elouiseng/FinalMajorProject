using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMapScript : MonoBehaviour
{
    public Button openPopUpButton, closePopUpButton, settingsButton, quitButton, nextLevelMapButton;
    public Button level1Button, level2Button, level3Button, level4Button, level5Button;
    public Button level1PlayButton;
    public GameObject rightPopUp, level1PopUp, level2PopUp;
    public AudioClip buttonSound;

    private void Awake()
    {
        openPopUpButton.onClick.AddListener(OpenRightPopUp);
        closePopUpButton.onClick.AddListener(CloseRightPopUp);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);

        level1Button.onClick.AddListener(OpenLevel1PopUp);


    }
    // Start is called before the first frame update
    void Start()
    {
        rightPopUp.SetActive(false);
        level1PopUp.SetActive(false);
        level2PopUp.SetActive(false);
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

    void OpenLevel1PopUp()
    {
        level1PlayButton.onClick.AddListener(StartLevel1);
        level1Button.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        level1PopUp.SetActive(true);
    }

    void OpenLevel2PopUp()
    {

    }

    void StartLevel1()
    {
        level1PlayButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("Level1Scene");
    }
    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
