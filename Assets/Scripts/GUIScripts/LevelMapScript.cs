using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMapScript : MonoBehaviour
{
    [SerializeField] Button openPopUpButton, closePopUpButton, settingsButton, quitButton, nextLevelMapButton;
    [SerializeField] Button level1Button, level2Button, level3Button, level4Button, level5Button;
    [SerializeField] Button closeL1PopUpButton, closeL2PopUpButton, closeL3PopUpButton, closeL4PopUpButton, closeL5PopUpButton;
    [SerializeField] Button level1PlayButton, level2PlayButton;
    [SerializeField] AudioClip buttonSound;
    [SerializeField] TextMeshProUGUI level1HighscoreT;

    private GameObject rightPopUp, level1PopUp, level2PopUp, level3PopUp, level4PopUp, level5PopUp, nextLevelMapB;



    private void Awake()
    {
        rightPopUp = GameObject.Find("/Canvas/RightPopUp");
        level1PopUp = GameObject.Find("LevelStartPopUps/Level1PopUp");
        level2PopUp = GameObject.Find("LevelStartPopUps/Level2PopUp");
        level3PopUp = GameObject.Find("LevelStartPopUps/Level3PopUp");
        level4PopUp = GameObject.Find("LevelStartPopUps/Level4PopUp");
        level5PopUp = GameObject.Find("LevelStartPopUps/Level5PopUp");
        nextLevelMapB = GameObject.Find("/Canvas/NextLevelMapButton");

        openPopUpButton.onClick.AddListener(OpenRightPopUp);
        closePopUpButton.onClick.AddListener(CloseRightPopUp);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);

        LevelButtonsOnAwake();
    }
    // Start is called before the first frame update
    void Start()
    {
        rightPopUp.SetActive(false);
        level1PopUp.SetActive(false);
        level2PopUp.SetActive(false);
        level3PopUp.SetActive(false);
        level4PopUp.SetActive(false);
        level5PopUp.SetActive(false);

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
        if (level2PopUp.activeSelf == false)
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
        SceneManager.LoadScene("Level2Scene");
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


    void LevelButtonsOnAwake()
    {
        level1Button.onClick.AddListener(OpenLevel1PopUp);
        level2Button.onClick.AddListener(OpenLevel2PopUp);
        level3Button.onClick.AddListener(OpenLevel3PopUp);
        level4Button.onClick.AddListener(OpenLevel4PopUp);
        level5Button.onClick.AddListener(OpenLevel5PopUp);

        level1PlayButton.onClick.AddListener(StartLevel1);
        level2PlayButton.onClick.AddListener(StartLevel2);

        closeL1PopUpButton.onClick.AddListener(CloseLevel1PopUp);
        closeL2PopUpButton.onClick.AddListener(CloseLevel2PopUp);
        closeL3PopUpButton.onClick.AddListener(CloseLevel3PopUp);
        closeL4PopUpButton.onClick.AddListener(CloseLevel4PopUp);
        closeL5PopUpButton.onClick.AddListener(CloseLevel5PopUp);
    }

    void OpenLevel3PopUp()
    {
        if (level2PopUp.activeSelf == false)
        {
            level3Button.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            StartCoroutine(WaitForSound());
            level3PopUp.SetActive(true);
        }
    }

    void OpenLevel4PopUp()
    {
        if (level2PopUp.activeSelf == false)
        {
            level4Button.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            StartCoroutine(WaitForSound());
            level4PopUp.SetActive(true);
        }
    }

    void OpenLevel5PopUp()
    {
        if (level2PopUp.activeSelf == false)
        {
            level5Button.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            StartCoroutine(WaitForSound());
            level5PopUp.SetActive(true);
        }
    }

    void CloseLevel3PopUp()
    {
        closeL3PopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        level3PopUp.SetActive(false);
    }
    void CloseLevel4PopUp()
    {
        closeL4PopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        level4PopUp.SetActive(false);
    }
    void CloseLevel5PopUp()
    {
        closeL5PopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        level5PopUp.SetActive(false);
    }
}
