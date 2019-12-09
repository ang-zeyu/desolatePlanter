using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;
    [SerializeField] [Range(1f, 10f)] float winDisplayTime = 5f;
    [SerializeField] Canvas loseCanvas;

    [Header("Audio")]
    [SerializeField] AudioClip winClip;
    [SerializeField] AudioClip loseClip;
    [SerializeField] [Range(0f, 1f)] float volume = 0.5f;

    Loader sceneLoader;

    bool isTimerUp;
    int enemiesLeft;

    void Start()
    {
        winCanvas.enabled = false;
        loseCanvas.enabled = false;

        sceneLoader = FindObjectOfType<Loader>();
    }

    public void SetTimerUp(bool isTimerUp)
    {
        this.isTimerUp = isTimerUp;
        VictoryHandler();
    }

    public void SetEnemiesLeft(int amt)
    {
        enemiesLeft = amt;
        VictoryHandler();
    }

    public void LoseHandler()
    {
        Time.timeScale = 0f;
        loseCanvas.enabled = true;
        AudioSource.PlayClipAtPoint(loseClip, Camera.main.transform.position);
    }

    private void VictoryHandler()
    {
        if (enemiesLeft <= 0 && isTimerUp)
        {
            StartCoroutine(VictoryRoutine());
        }
    }

    IEnumerator VictoryRoutine()
    {
        AudioSource.PlayClipAtPoint(winClip, Camera.main.transform.position);
        winCanvas.enabled = true;
        Debug.Log(winCanvas.enabled);
        yield return new WaitForSeconds(winDisplayTime);
        sceneLoader.LoadNext();
    }
}
