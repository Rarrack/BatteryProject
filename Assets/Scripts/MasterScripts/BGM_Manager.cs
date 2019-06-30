using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGM_Manager : MonoBehaviour
{

    public static BGM_Manager instance;

    public AudioFile[] audioFiles;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach(AudioFile file in audioFiles)
        {
            file.source = gameObject.AddComponent<AudioSource>();
            file.source.clip = file.audioClip;
            file.source.volume = file.volume;
            file.source.loop = file.isLooping;

            if(file.playOnAwake)
            {
                if (PlayerPrefs.HasKey("BGM Volume"))
                {
                    file.source.volume = PlayerPrefs.GetFloat("BGM Volume");
                    file.source.Play();
                }
                else
                {
                    file.source.Play();
                }
            }
        }
    }

    void Start()
    {
        
    }

    public static void PlayMusic(string name)
    {
        AudioFile file = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);
        file.source.Play();
    }

    public static void StopMusic(string name)
    {
        AudioFile file = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);
        file.source.Stop();
    }

    public static void PauseMusic(string name)
    {
        AudioFile file = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);
        file.source.Pause();
    }

    public static void UnPauseMusic(string name)
    {
        AudioFile file = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);
        file.source.UnPause();
    }
}
