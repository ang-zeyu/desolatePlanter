using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashPlayer : MonoBehaviour
{
    [SerializeField] AudioClip splashTone;
    [SerializeField] float loadTime;

    Loader levelLoader;
    IEnumerator Start()
    {
        levelLoader = FindObjectOfType<Loader>();
        AudioSource.PlayClipAtPoint(splashTone, Camera.main.transform.position);
        yield return new WaitForSeconds(loadTime);
        levelLoader.LoadNext();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
