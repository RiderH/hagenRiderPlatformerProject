using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject WinText;
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenuNav()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
    }

    public void Win()
    {
        WinText.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
