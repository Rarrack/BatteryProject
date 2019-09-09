using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFX_Manager : MonoBehaviour
{
    public static SFX_Manager instance;
    public AudioFile[] soundFiles;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if (!PlayerPrefs.HasKey("SFX Volume"))
        {
            PlayerPrefs.SetFloat("SFX Volume", 0.7f);
        }

        foreach (AudioFile file in soundFiles)
        {
            file.source = gameObject.AddComponent<AudioSource>();
            file.source.clip = file.audioClip;
            file.source.volume = PlayerPrefs.GetFloat("SFX Volume");
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

    public void PlaySound(string name)
    {
        AudioFile file = Array.Find(instance.soundFiles, AudioFile => AudioFile.audioName == name);
        file.source.Play();
    }

    public void StopSound(string name)
    {
        AudioFile file = Array.Find(instance.soundFiles, AudioFile => AudioFile.audioName == name);
        file.source.Stop();
    }

    public void PauseSound(string name)
    {
        AudioFile file = Array.Find(instance.soundFiles, AudioFile => AudioFile.audioName == name);
        file.source.Pause();
    }

    public void UnPauseSound(string name)
    {
        AudioFile file = Array.Find(instance.soundFiles, AudioFile => AudioFile.audioName == name);
        file.source.UnPause();
    }
}
