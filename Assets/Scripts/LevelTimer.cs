using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] float levelTime;

    bool levelOver = false;

    //Cached reference
    Slider slider;
    LevelController level;
    EnemySpawner levelSpawner;

    void Start()
    {
        slider = GetComponent<Slider>();
        level = FindObjectOfType<LevelController>();
        levelSpawner = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelTime;
        if (slider.value >= 1 && !levelOver)
        {
            levelOver = true;
            level.SetTimerUp(true);
            levelSpawner.TurnSpawnOff();
            
        }
    }
}
