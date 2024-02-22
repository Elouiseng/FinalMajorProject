using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Button graphicsButton, audioButton, otherButton;
    public Button closeSettingsButton;

    private static int previousSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        closeSettingsButton.onClick.AddListener(CloseSettings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseSettings()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }

    public static void SetPreviousSceneIndex(int sceneIndex)
    {
        previousSceneIndex = sceneIndex;
    }
}
