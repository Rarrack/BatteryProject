using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGM_Manager : MonoBehaviour
{
    public static BGM_Manager instance;
    public AudioFile[] musicFiles;

    int StageCheck(int level)
    {
        if(level >= 2 && level <=7)
        {
            return 1;
        }
        if (level >= 8 && level <= 13)
        {
            return 2;
        }
        if (level >= 14 && level <= 19)
        {
            return 3;
        }
        if (level >= 20 && level <= 25)
        {
            return 4;
        }
        if (level >= 26 && level <= 31)
        {
            return 5;
        }

        return 0;
    }

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


    public void PlayStageMusic(int level)
    {
        switch (StageCheck(level))
        {
            case 1:
                PlayMusic("Stage 1 Theme");
                break;
            case 2:
                PlayMusic("Stage 2 Theme");
                break;
            case 3:
                PlayMusic("Stage 3 Theme");
                break;
            case 4:
                PlayMusic("Stage 4 Theme");
                break;
            case 5:
                PlayMusic("Stage 5 Theme");
                break;
            default:
                break;
        }
    }

    public void StopMusic(string name)
    {
        AudioFile file = Array.Find(instance.musicFiles, AudioFile => AudioFile.audioName == name);
        file.source.Stop();
    }

    public void StopStageMusic(int level)
    {
        switch (StageCheck(level))
        {
            case 1:
                StopMusic("Stage 1 Theme");
                break;
            case 2:
                StopMusic("Stage 2 Theme");
                break;
            case 3:
                StopMusic("Stage 3 Theme");
                break;
            case 4:
                StopMusic("Stage 4 Theme");
                break;
            case 5:
                StopMusic("Stage 5 Theme");
                break;
            default:
                break;
        }
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
