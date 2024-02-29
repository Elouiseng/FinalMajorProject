using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenuScript : MonoBehaviour
{
    public Button playButton, settingButton, quitButton;
    public AudioClip buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        settingButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// BUG: Sometimes Button is not playing sound!!!!!!!!!!!!!!!!!!!!
    /// </summary>

    void StartGame()
    {
        playButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
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
        quitButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        Application.Quit();
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
