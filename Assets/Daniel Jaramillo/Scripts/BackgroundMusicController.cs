using System;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public static BackgroundMusicController Instance { get; private set; }
    
    private AudioSource audioSource;
    public AudioClip audioLevel1;
    public AudioClip audioLevel2;
    public AudioClip audioLevel3;


    private void Awake()
    {
        if (Instance != null & Instance != this) Destroy(this);
        else Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioLevel1;
        audioSource.Play();
    }

    public void StartLevel2Music()
    {
        audioSource.clip = audioLevel2;
        audioSource.Play();
    }
    public void StartLevel3Music()
    {
        audioSource.clip = audioLevel3;
        audioSource.Play();
    }
}
