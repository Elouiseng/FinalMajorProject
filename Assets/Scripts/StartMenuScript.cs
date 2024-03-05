using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenuScript : MonoBehaviour
{
    public Button playButton, settingButton, quitButton;
    public AudioMixer audioMixer;
    public AudioClip buttonSound;

    private void Awake()
    {
        playButton.onClick.AddListener(StartGame);
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
