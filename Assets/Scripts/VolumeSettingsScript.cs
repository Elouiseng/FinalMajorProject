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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMainVolumeChange(float arg0)
    {
        float volume = mainVolumeSlider.value;
        audioMixer.SetFloat("MainParam", Mathf.Log10(volume) * 20);
    }

    private void OnMusicVolumeChange(float arg0)
    {
        float volume = musicVolumeSlider.value;
        audioMixer.SetFloat("MusicParam", Mathf.Log10(volume) * 20);
    }

    private void OnFxVolumeChange(float arg0)
    {
        float volume = fxVolumeSlider.value;
        audioMixer.SetFloat("FxParam", Mathf.Log10(volume) * 20);
    }
}
