using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //Cached reference
    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);

        CleanUpOtherPlayers();
    }

    private void CleanUpOtherPlayers()
    {
        MusicPlayer[] players = FindObjectsOfType<MusicPlayer>();
        foreach (MusicPlayer musicPlayer in players)
        {
            if (musicPlayer != this)
            {
                if (musicPlayer.GetComponent<AudioSource>().clip != audioSrc.clip)
                {
                    Destroy(musicPlayer.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void UpdateVolume(float volume)
    {
        audioSrc.volume = volume;
    }

    private void Update()
    {
        UpdateVolume(PlayerPrefsController.GetMasterVolume());
    }
}
