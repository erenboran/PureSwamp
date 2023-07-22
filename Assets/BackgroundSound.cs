using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    public static BackgroundSound Instance;

    AudioSource audioSource;

    public float volume
    {
        get { return PlayerPrefs.GetFloat("volume", 0.5f); }
        set { PlayerPrefs.SetFloat("volume", value); }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    public void ChangeSoundVolume(float volume)
    {
        this.volume = volume;
        
        audioSource.volume = volume;
    }


}
