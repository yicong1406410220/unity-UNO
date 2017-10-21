using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnoSetting : MonoBehaviour {

    public Slider slider;
    
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("speed");
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

}
