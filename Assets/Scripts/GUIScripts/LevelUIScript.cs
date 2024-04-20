using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class LevelUIScript : MonoBehaviour
{
    [SerializeField] Button openRightPopUpButton, closeRightPopUpButton, restartButton, homeButton, settingButton, quitButton, finishRestartButton, finishContinueButton;
    [SerializeField] AudioClip buttonSound;
    [SerializeField] TextMeshProUGUI timeText, scoreText, levelText, finishScoreText, highscoreText;
    [SerializeField] string levelName;
    [SerializeField] float amountTime;
    [SerializeField] AudioMixer audioMixer;


    private float timeRemaining;
    private bool timerIsRunning;
    public int earnedPoints;
    private GameObject rightPopUp, finishingImage;

    private void Awake()
    {
        rightPopUp = GameObject.Find("RightPopUp");
        finishingImage = GameObject.Find("FinishingImage");

        openRightPopUpButton.onClick.AddListener(OpenRightPopUp);
        closeRightPopUpButton.onClick.AddListener(CloseRightPopUp);
        restartButton.onClick.AddListener(RestartLevel);
        homeButton.onClick.AddListener(OpenLevelMap);
        settingButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);
        finishRestartButton.onClick.AddListener(RestartLevel);
        finishContinueButton.onClick.AddListener(OpenLevelMap);

        earnedPoints = 0;
        timeRemaining = amountTime;
        timerIsRunning = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("MainParam", Mathf.Log10(PlayerPrefs.GetFloat("MainVolume")) * 20);
        audioMixer.SetFloat("MusicParam", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20);
        audioMixer.SetFloat("FxParam", Mathf.Log10(PlayerPrefs.GetFloat("FxVolume")) * 20);

        scoreText.text += " " + earnedPoints;
        levelText.text += " " + levelName;

        rightPopUp.SetActive(false);
        finishingImage.SetActive(false);
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            LevelTimer();
            DisplayPoints();
        }
    }

    #region GUI 
    void OpenRightPopUp() 
    {
        openRightPopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        timerIsRunning = false;
        rightPopUp.SetActive(true);
    }

    void CloseRightPopUp()
    {
        closeRightPopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        timerIsRunning = true;
        rightPopUp.SetActive(false);
    }

    void RestartLevel()
    {
        restartButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OpenLevelMap()
    {
        homeButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("LevelMapScene");
    }

    void OpenSettings()
    {
        settingButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("previousScene", currentScene);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("SettingsScene");
    }

    void QuitGame()
    {
        Application.Quit(); 
    }

    #endregion



    void LevelTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTimer(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;
            finishingImage.SetActive(true);
            OnLevelFinish();
        }
    }

    void DisplayTimer(float timeDisplayed)
    {
        float minutes = Mathf.FloorToInt(timeDisplayed / 60);
        float seconds = Mathf.FloorToInt(timeDisplayed % 60);
        float milliSeconds = (timeDisplayed % 1) * 1000;

        timeText.text = string.Format(" {0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    void DisplayPoints()
    {
        scoreText.text = earnedPoints.ToString();
    }

    void OnLevelFinish()
    {
        finishScoreText.text = earnedPoints.ToString();

        if (earnedPoints > PlayerPrefs.GetInt("LevelOneHighscore"))
        {
            PlayerPrefs.SetInt("LevelOneHighscore", earnedPoints);
        }

        highscoreText.text = PlayerPrefs.GetInt("LevelOneHighscore").ToString();
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
