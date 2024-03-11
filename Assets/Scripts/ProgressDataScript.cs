using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressDataScript : MonoBehaviour
{
    private void Awake()
    {
        CreatePlayerPrefs();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("previousScene"))
        {
            PlayerPrefs.SetInt("previousScene", 0);
        }
        if (!PlayerPrefs.HasKey("DisplayModeOption"))
        {
            PlayerPrefs.SetInt("DisplayModeOption", 0);
        }
        if (!PlayerPrefs.HasKey("ResolutionOption"))
        {
            PlayerPrefs.SetInt("ResolutionOption", 0);
        }
        if (!PlayerPrefs.HasKey("MainVolume"))
        {
            PlayerPrefs.SetFloat("MainVolume", 1f);
        }
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1f);
        }
        if (!PlayerPrefs.HasKey("FxVolume"))
        {
            PlayerPrefs.SetFloat("FxVolume", 1f);
        }
        if (!PlayerPrefs.HasKey("FinishedLevel"))
        {
            PlayerPrefs.SetInt("FinishedLevel", 0);
        }
        if (!PlayerPrefs.HasKey("LevelOneHighscore"))
        {
            PlayerPrefs.SetInt("LevelOneHighscore", 0);
        }
        if (!PlayerPrefs.HasKey("LevelTwoHighscore"))
        {
            PlayerPrefs.SetInt("LevelTwoHighscore", 0);
        }
    }
}
