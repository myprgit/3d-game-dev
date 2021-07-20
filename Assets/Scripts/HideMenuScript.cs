using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideMenuScript : MonoBehaviour
{
    private GameObject winLoseObj;
    private GameObject goToMainObj;
    private GameObject restartObj;

    private void Awake()
    {
        winLoseObj = GameObject.Find("WinLose");
        goToMainObj = GameObject.Find("GoToMainMenu");
        restartObj = GameObject.Find("Restart");
        Time.timeScale = 1f;
    }
    private void Start()
    {
        winLoseObj.SetActive(false);
        goToMainObj.SetActive(false);
        restartObj.SetActive(false);
        Time.timeScale = 1f;
    }

    public void goToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
