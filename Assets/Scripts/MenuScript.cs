using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    GameObject mMenu;
    GameObject lsMenu;
    GameObject stMenu;
    public Text btnText;
    public Text valueText;
    public Slider slider;
    float currentSliderValue;
    private bool valueChangedByCode = false;
    private void Awake()
    {
        Time.timeScale = 1f;
        slider.value = PlayerPrefs.GetFloat("Sound")*100;
    }
    private void Start()
    {
        Time.timeScale = 1f;
        mMenu = GameObject.Find("MainMenu");
        lsMenu = GameObject.Find("LevelSelectMenu");
        stMenu = GameObject.Find("SettingsMenu");
        currentSliderValue = slider.value;
        lsMenu.SetActive(false);
        stMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Debug.Log("Exit Working");
        Application.Quit();
    }

    public void OpenLevelSelect()
    {
        lsMenu.SetActive(true);
        mMenu.SetActive(false);
    }

    public void OpenSettings()
    {
        stMenu.SetActive(true);
        mMenu.SetActive(false);
    }
    public void BackToMain()
    {
        lsMenu.SetActive(false);
        stMenu.SetActive(false);
        mMenu.SetActive(true);
    }

    public void LoadTraining()
    {
        SceneManager.LoadScene("Training");
    }

    public void LoadEasy()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadHard()
    {
        SceneManager.LoadScene("Level2");
    }

    public void SoundOnOff()
    {
        valueChangedByCode = true;
        if(btnText.text == "Off")
        {
            btnText.text = "On";
            valueText.text = "0";
            slider.value = 0;
            PlayerPrefs.SetInt("Sound", 0);
            PlayerPrefs.Save();
        }
        else if(btnText.text == "On")
        {
            btnText.text = "Off";
            valueText.text = currentSliderValue.ToString();
            if(currentSliderValue == 0)
            {
                currentSliderValue = 100;
            }
            slider.value = currentSliderValue;
            PlayerPrefs.SetFloat("Sound", currentSliderValue/100);
            PlayerPrefs.Save();
        }
    }

    public void OnValueChanged()
    {
        if(valueChangedByCode)
        {
            valueChangedByCode = false;
            return;
        }
        currentSliderValue = slider.value;
        btnText.text = "Off";
        valueText.text = currentSliderValue.ToString();
        PlayerPrefs.SetFloat("Sound", currentSliderValue/100);
        PlayerPrefs.Save();
    }
}
