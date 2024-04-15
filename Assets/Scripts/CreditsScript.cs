using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    [SerializeField] Button exitCreditsButton;
    [SerializeField] AudioClip buttonSound;

    private void Awake()
    {
        exitCreditsButton.onClick.AddListener(ExitCredits);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ExitCredits()
    {
        Debug.Log("Button pressed");
        exitCreditsButton.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        StartCoroutine(WaitForSound());
        SceneManager.LoadScene("SettingsScene");
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
