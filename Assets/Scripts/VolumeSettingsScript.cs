using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettingsScript : MonoBehaviour
{
    public Slider mainVolumeSlider, musicVolumeSlider, fxVolumeSlider;
    public AudioMixer audioMixer;
    public AudioMixerGroup mainAudioMixer, musicAudioMixer, fxAudioMixer;


    // Start is called before the first frame update
    void Start()
    {
        mainVolumeSlider.onValueChanged.AddListener(OnMainVolumeChange);
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChange);
        fxVolumeSlider.onValueChanged.AddListener(OnFxVolumeChange);

        Debug.Log("PlayerP: " + PlayerPrefs.GetFloat("MainVolume"));

        mainVolumeSlider.value = PlayerPrefs.GetFloat("MainVolume");
        Debug.Log("PlayerP: " + PlayerPrefs.GetFloat("MainVolume"));
        Debug.Log("Volume value: " + mainVolumeSlider.value);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        fxVolumeSlider.value = PlayerPrefs.GetFloat("FxVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMainVolumeChange(float arg0)
    {
        float volume = mainVolumeSlider.value;
        audioMixer.SetFloat("MainParam", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MainVolume", volume);
    }

    private void OnMusicVolumeChange(float arg0)
    {
        float volume = musicVolumeSlider.value;
        audioMixer.SetFloat("MusicParam", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    private void OnFxVolumeChange(float arg0)
    {
        float volume = fxVolumeSlider.value;
        audioMixer.SetFloat("FxParam", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("FxVolume", volume);
    }
}
