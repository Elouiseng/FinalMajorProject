using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelUIScript : MonoBehaviour
{
    [SerializeField] Button openRightPopUpButton, closeRightPopUpButton, homeButton;
    [SerializeField] AudioClip buttonSound;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] string levelName;
    [SerializeField] float amountTime;

    private float timeRemaining;
    private bool timerIsRunning;
    private int earnedPoints;
    private GameObject rightPopUp;

    private void Awake()
    {
        rightPopUp = GameObject.Find("/Canvas/RightPopUp");

        openRightPopUpButton.onClick.AddListener(OpenRightPopUp);
        closeRightPopUpButton.onClick.AddListener(CloseRightPopUp);
        homeButton.onClick.AddListener(OpenLevelMap);

        earnedPoints = 0;
        timeRemaining = amountTime;
        timerIsRunning = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text += " " + earnedPoints;
        levelText.text += " " + levelName;

        rightPopUp.SetActive(false);
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        LevelTimer();
    }

    void OpenRightPopUp() 
    {
        openRightPopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        rightPopUp.SetActive(true);
    }

    void CloseRightPopUp()
    {
        closeRightPopUpButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        rightPopUp.SetActive(false);
    }

    void OpenLevelMap()
    {
        homeButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("LevelMapScene");
    }

    void LevelTimer()
    {
        if (timerIsRunning)
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
            }
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
        
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
