using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGM_Manager : MonoBehaviour
{
    public static BGM_Manager instance;
    public AudioFile[] musicFiles;

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

        if (!PlayerPrefs.HasKey("BGM Volume"))
        {
            PlayerPrefs.SetFloat("BGM Volume", 0.7f);
        }

        foreach (AudioFile file in musicFiles)
        {
            file.source = gameObject.AddComponent<AudioSource>();
            file.source.clip = file.audioClip;
            file.source.volume = PlayerPrefs.GetFloat("BGM Volume");
            file.source.loop = file.isLooping;

            //if(file.playOnAwake)
            //{
            //    if (PlayerPrefs.HasKey("BGM Volume"))
            //    {
            //        file.source.volume = PlayerPrefs.GetFloat("BGM Volume");
            //        file.source.Play();
            //    }
            //    else
            //    {
            //        file.source.Play();
            //    }
            //}
        }
    }

    void Start()
    {
        
    }

    public void PlayMusic(string name)
    {
        AudioFile file = Array.Find(instance.musicFiles, AudioFile => AudioFile.audioName == name);
        file.source.Play();
    }

    public void StopMusic(string name)
    {
        AudioFile file = Array.Find(instance.musicFiles, AudioFile => AudioFile.audioName == name);
        file.source.Stop();
    }

    public void PauseMusic(string name)
    {
        AudioFile file = Array.Find(instance.musicFiles, AudioFile => AudioFile.audioName == name);
        file.source.Pause();
    }

    public void UnPauseMusic(string name)
    {
        AudioFile file = Array.Find(instance.musicFiles, AudioFile => AudioFile.audioName == name);
        file.source.UnPause();
    }
}
