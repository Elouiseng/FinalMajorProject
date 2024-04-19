using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMapScript : MonoBehaviour
{
    [SerializeField] Button openPopUpButton, closePopUpButton, settingsButton, quitButton, nextLevelMapButton;
    [SerializeField] Button level1Button, closeL1PopUpButton, level2Button, closeL2PopUpButton;
    [SerializeField] Button level1PlayButton, level2PlayButton;
    [SerializeField] AudioClip buttonSound;
    [SerializeField] TextMeshProUGUI level1HighscoreT;

    private GameObject rightPopUp, level1PopUp, level2PopUp, nextLevelMapB;



    private void Awake()
    {
        rightPopUp = GameObject.Find("/Canvas/RightPopUp");
        level1PopUp = GameObject.Find("LevelStartPopUps/Level1PopUp");
        level2PopUp = GameObject.Find("LevelStartPopUps/Level2PopUp");
        nextLevelMapB = GameObject.Find("/Canvas/NextLevelMapButton");

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

    #region Right Side Pop Up
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
    #endregion

    #region Level 1
    void OpenLevel1PopUp()
    {
        if (level2PopUp.activeSelf ==  false)
        {        
            level1Button.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            StartCoroutine(WaitForSound());
            DisplayHighscore();
            level1PopUp.SetActive(true);
        }
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

    void DisplayHighscore()
    {
        level1HighscoreT.text = PlayerPrefs.GetInt("LevelOneHighscore").ToString();
    }
    #endregion

    #region Level 2
    void OpenLevel2PopUp()
    {
        if (level1PopUp.activeSelf == false)
        {
            level2Button.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            StartCoroutine(WaitForSound());
            level2PopUp.SetActive(true);
        }
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
