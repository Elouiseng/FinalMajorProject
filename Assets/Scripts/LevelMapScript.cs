using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMapScript : MonoBehaviour
{
    public Button settingButton;

    // Start is called before the first frame update
    void Start()
    {
        settingButton.onClick.AddListener(SettingOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SettingOnClick()
    {
        SceneManager.LoadScene(2);
    }
}
