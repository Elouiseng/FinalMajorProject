using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] AudioClip buttonSound;


    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(CloseCredits);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseCredits()
    {
        closeButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("SettingsScene");
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
