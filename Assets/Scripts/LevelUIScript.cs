using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIScript : MonoBehaviour
{
    [SerializeField] Button openRightPopUpButton, closeRightPopUpButton, homeButton;
    [SerializeField] AudioClip buttonSound;


    private GameObject rightPopUp;

    private void Awake()
    {
        rightPopUp = GameObject.Find("/Canvas/RightPopUp");

        openRightPopUpButton.onClick.AddListener(OpenRightPopUp);
        closeRightPopUpButton.onClick.AddListener(CloseRightPopUp);
        homeButton.onClick.AddListener(OpenLevelMap);
    }

    // Start is called before the first frame update
    void Start()
    {
        rightPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(buttonSound.length);
    }
}
