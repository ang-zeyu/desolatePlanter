using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string VOLUME = "Volume";
    const string DIFFICULTY = "Difficulty";

    const float MAX_VOLUME = 1f;
    const float MIN_VOLUME = 0f;

    const int MAX_DIFFICULTY = 3;
    const int MIN_DIFFICULTY = 1;

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME);
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY);
    }

    public static void SetMasterVolume(float val)
    {
        if (val <= MAX_VOLUME && val >= MIN_VOLUME)
        {
            PlayerPrefs.SetFloat(VOLUME, val);
        }
        else
        {
            throw new ArgumentException("Volume out of bounds");
        }
    }

    public static void SetDifficulty(int val)
    {
        if (val <= MAX_DIFFICULTY && val >= MIN_DIFFICULTY)
        {
            PlayerPrefs.SetInt(DIFFICULTY, val);
        }
        else
        {
            throw new ArgumentException("Difficulty out of bounds");
        }
    }
}
