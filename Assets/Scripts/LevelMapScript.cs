using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMapScript : MonoBehaviour
{
    public Button openPopUpButton, closePopUpButton, settingsButton, quitButton, nextLevelMapButton;
    public Button level1Button, closeL1PopUpButton, level2Button, closeL2PopUpButton;
    public Button level1PlayButton, level2PlayButton;
    public GameObject rightPopUp, level1PopUp, level2PopUp, nextLevelMapB;
    public AudioClip buttonSound;

    private void Awake()
    {
        openPopUpButton.onClick.AddListener(OpenRightPopUp);
        closePopUpButton.onClick.AddListener(CloseRightPopUp);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);

        level1Button.onClick.AddListener(OpenLevel1PopUp);
        level1PlayButton.onClick.AddListener(StartLevel1);
        closeL1PopUpButton.onClick.AddListener(CloseLevel1PopUp);

        level2Button.onClick.AddListener(OpenLevel2PopUp);
        level2PlayButton.onClick.AddListener(StartLevel2);
        closeL2PopUpButton.onClick.AddListener(CloseLevel2PopUp);
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
        nextLevelMapB.SetActive(false);
        StartCoroutine(WaitForSound());
        rightPopUp.SetActive(true);
    }

    void CloseRightPopUp()
    {
        closePopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound); //BUG: This button doesn't play sound!!!!!!!!!!!!!!!!!!!!!!!
        nextLevelMapB.SetActive(true);
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

    #region Level 1
    void OpenLevel1PopUp()
    {
        level1Button.GetComponent<AudioSource>().PlayOneShot(buttonSound);

        StartCoroutine(WaitForSound());
        level1PopUp.SetActive(true);
    }

    void StartLevel1()
    {
        level1PlayButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("Level1Scene");
    }

    void CloseLevel1PopUp()
    {
        closeL1PopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        level1PopUp.SetActive(false);
    }
    #endregion

    #region Level 2
    void OpenLevel2PopUp()
    {
        level2PlayButton.onClick.AddListener(StartLevel1);
        level2Button.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        level1PopUp.SetActive(true);
    }

    void StartLevel2()
    {
        level2PlayButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        //SceneManager.LoadScene("Level2Scene");
    }

    void CloseLevel2PopUp()
    {
        closeL2PopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        level2PopUp.SetActive(false);
    }
    #endregion

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
