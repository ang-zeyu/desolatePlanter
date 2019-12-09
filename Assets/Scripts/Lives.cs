using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 10;

    //Cached reference
    TextMeshProUGUI livesText;
    LevelController level;

    void Start()
    {
        lives -= PlayerPrefsController.GetDifficulty() * 2;
        livesText = GetComponent<TextMeshProUGUI>();
        UpdateText();
        level = FindObjectOfType<LevelController>();
    }

    public void DecLives(int amt)
    {
        lives -= amt;
        UpdateText();

        if (lives <= 0)
        {
            level.LoseHandler();
        }
    }

    public void IncLives(int amt)
    {
        lives += amt;
        UpdateText();
    }

    private void UpdateText()
    {
        livesText.text = lives.ToString();
    }
}
