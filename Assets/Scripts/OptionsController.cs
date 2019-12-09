using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    public void SetVolume()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    }

    public void SetDifficulty()
    {
        PlayerPrefsController.SetDifficulty((int) difficultySlider.value);
    }
}
