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

        openRightPopUpButton.onClick.AddListener(() => TogglePopUp(true));
        closeRightPopUpButton.onClick.AddListener(() => TogglePopUp(false));
        restartButton.onClick.AddListener(() => LoadSceneWithSound(SceneManager.GetActiveScene().name));
        homeButton.onClick.AddListener(() => LoadSceneWithSound("LevelMapScene"));
        settingButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(Application.Quit);
        finishRestartButton.onClick.AddListener(() => LoadSceneWithSound(SceneManager.GetActiveScene().name));
        finishContinueButton.onClick.AddListener(() => LoadSceneWithSound("LevelMapScene"));

        earnedPoints = 0;
        timeRemaining = amountTime;
        timerIsRunning = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupAudio();

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

    private void SetupAudio()
    {
        audioMixer.SetFloat("MainParam", Mathf.Log10(PlayerPrefs.GetFloat("MainVolume")) * 20);
        audioMixer.SetFloat("MusicParam", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20);
        audioMixer.SetFloat("FxParam", Mathf.Log10(PlayerPrefs.GetFloat("FxVolume")) * 20);
    }

    private void PlaySound(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    void TogglePopUp(bool isOpen)
    {
        PlaySound(buttonSound);
        StartCoroutine(WaitForSound(() => {
            timerIsRunning = !isOpen;
            rightPopUp.SetActive(isOpen);
        }));
    }

    private void LoadSceneWithSound(string sceneName)
    {
        PlaySound(buttonSound);
        StartCoroutine(WaitForSound(() => SceneManager.LoadScene(sceneName)));
    }

    void OpenSettings()
    {
        PlaySound(buttonSound);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("previousScene", currentScene);
        StartCoroutine(WaitForSound(() => SceneManager.LoadScene("SettingsScene")));
    }

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

    IEnumerator WaitForSound(System.Action callback)
    {
        yield return new WaitForSeconds(buttonSound.length);
        callback?.Invoke();
    }
}
