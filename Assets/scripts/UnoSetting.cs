using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnoSetting : MonoBehaviour {

    public Slider slider;

    public Toggle toggle;

    public AudioSource audioSource;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("speed");
        int ison = PlayerPrefs.GetInt("MusicSetting", 1);
        if (ison == 1)
        {
            toggle.isOn = true;
            audioSource.mute = false;
        }
        else
        {
            toggle.isOn = false;
            audioSource.mute = true;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingClose()
    {
        this.gameObject.SetActive(false);
    }

    public void SettingOpen()
    {
        this.gameObject.SetActive(true);
    }

    public void GetSliderValue()
    {
        PlayerPrefs.SetFloat("speed", slider.value);
        
    }

    public void SetMusic(bool value)
    {
        if (value)
        {
            PlayerPrefs.SetInt("MusicSetting", 1);
            audioSource.mute = false;
        }
        else
        {
            PlayerPrefs.SetInt("MusicSetting", 0);
            audioSource.mute = true;
        }
    }
}
