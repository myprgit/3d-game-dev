using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountEnemyScript : MonoBehaviour
{

    private GameObject[] zombies;
    public int count;
    public Text text;
    public Text winLose;
    private GameObject winLoseObj;
    private GameObject goToMainObj;
    private GameObject restartObj;

    private int getCount()
    {
        int c = 0;
        foreach (GameObject zombie in zombies)
        {
            c += zombie.GetComponent<EnemyController>().health <= 0 ? 1 : 0;
        }
        return c;
    }

    private void Awake()
    {
        winLoseObj = GameObject.Find("WinLose");
        goToMainObj = GameObject.Find("GoToMainMenu");
        restartObj = GameObject.Find("Restart");
        zombies = GameObject.FindGameObjectsWithTag("Enemy");
        count = getCount();
        text.text = count.ToString();
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        winLoseObj.SetActive(false);
        goToMainObj.SetActive(false);
        restartObj.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = count.ToString();
        if (count <= 0)
        {
            Time.timeScale = 0f;
            winLoseObj.SetActive(true);
            goToMainObj.SetActive(true);
            restartObj.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            winLose.text = "YOU WON!!!";
        }
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
