using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenuScript : MonoBehaviour
{
    public Button startButton, settingButton, quitButton;
    public AudioMixer audioMixer;
    public AudioClip buttonSound;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        settingButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("MainParam", Mathf.Log10(PlayerPrefs.GetFloat("MainVolume")) * 20);
        audioMixer.SetFloat("MusicParam", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20);
        audioMixer.SetFloat("FxParam", Mathf.Log10(PlayerPrefs.GetFloat("FxVolume")) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Gives the start button a sound and plays it.
    /// Waits for the sound to be finished, then opens the level map scene.
    /// </summary>
    void StartGame()
    {
        startButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("LevelMapScene");
    }

    /// <summary>
    /// Gives the settings button a sound and plays it.
    /// Saves index of current scene in a PlayerPref.
    /// Waits for the sound to be finished, then opens the settings scene.
    /// </summary>
    void OpenSettings()
    {
        settingButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("previousScene", currentScene);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("SettingsScene");
    }

    /// <summary>
    /// Gives the quit button a sound and plays it.
    /// Waits for the sound to be finished, then closes the game.
    /// </summary>
    void QuitGame()
    {
        quitButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        Application.Quit();
    }

    /// <summary>
    /// A method to make another method wate for the button sound.
    /// </summary>
    /// <returns>The length of the button sound</returns>
    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
