using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public void LoadNext()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void LoadOptions()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
