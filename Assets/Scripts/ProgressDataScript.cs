using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressDataScript : MonoBehaviour
{
    public Button deleteProgressButton;
    public AudioClip buttonSound;


    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("previousScene"))
        {
            PlayerPrefs.SetInt("previousScene", 0);
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

        deleteProgressButton.onClick.AddListener(DeleteProgressData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeleteProgressData()
    {
        deleteProgressButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("StartMenuScene");
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
