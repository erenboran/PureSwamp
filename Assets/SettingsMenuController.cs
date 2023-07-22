using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField]
    string mainSceneName;

    [SerializeField]
    float defaultSounVolume;

    [SerializeField]
    Button settingsMenuButton, startGameButton, soundButton, vibrationButton, backButton;

    [SerializeField]
    GameObject settingsMenuPanel, mainMenuPanel;

    [SerializeField]
    Sprite soundOnSprite, soundOffSprite, vibrationOnSprite, vibrationOffSprite;

    bool isSoundOn
    {
        get { return PlayerPrefs.GetInt("sound", 1) == 1; }
        set { PlayerPrefs.SetInt("sound", value ? 1 : 0); }
    }
    bool isVibrationOn = true;



    void Start()
    {
        settingsMenuButton.onClick.AddListener(OpenSettingsMenu);
        startGameButton.onClick.AddListener(StartGame);
        soundButton.onClick.AddListener(SoundOnOff);
        vibrationButton.onClick.AddListener(VibrationOnOff);
        backButton.onClick.AddListener(OpenMainMenu);

        if (isSoundOn)
        {
            soundButton.image.sprite = soundOnSprite;
           
        }

        else
        {
            soundButton.image.sprite = soundOffSprite;
          
        }


    }

    void OpenMainMenu()
    {
        settingsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    void OpenSettingsMenu()
    {
        settingsMenuPanel.SetActive(true);
        mainMenuPanel.SetActive(false);

    }

    void StartGame()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(mainSceneName);
    }

    void SoundOnOff()
    {
        if (!isSoundOn)
        {

            isSoundOn = true;
            soundButton.image.sprite = soundOnSprite;
                       BackgroundSound.Instance.ChangeSoundVolume(defaultSounVolume);

        }
        else
        {
            isSoundOn = false;
            soundButton.image.sprite = soundOffSprite;
            BackgroundSound.Instance.ChangeSoundVolume(0);

        }



    }


    void VibrationOnOff()
    {
        if (!isVibrationOn)
        {
            isVibrationOn = true;
            vibrationButton.image.sprite = vibrationOnSprite;

        }
        else
        {
            isVibrationOn = false;
            vibrationButton.image.sprite = vibrationOffSprite;
        }
    }





}
