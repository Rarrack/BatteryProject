using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetBGMVolume(float vol)
    {
        PlayerPrefs.SetFloat("BGM Volume", vol);
    }

    public void SetSFXVolume(float vol)
    {
        PlayerPrefs.SetFloat("SFX Volume", vol);
    }

    public void UpdateBGMVolumes()
    {
        foreach (AudioFile bgm in GameObject.Find("__bgm").GetComponent<BGM_Manager>().musicFiles)
        {
            bgm.source.volume = PlayerPrefs.GetFloat("BGM Volume");
        }
    }

    public void UpdateSFXVolumes()
    {
        foreach (AudioFile sfx in GameObject.Find("__sfx").GetComponent<SFX_Manager>().soundFiles)
        {
            sfx.source.volume = PlayerPrefs.GetFloat("SFX Volume");
        }
    }

    public void SlideBGM(int set)
    {
        if(set == 0)
        {
            GetComponent<Slider>().value += 0.1f;
            float newVolume = GetComponent<Slider>().value;
            PlayerPrefs.SetFloat("BGM Volume", newVolume);
        }
        else
        {
            GetComponent<Slider>().value -= 0.1f;
            float newVolume = GetComponent<Slider>().value;
            PlayerPrefs.SetFloat("BGM Volume", newVolume);
        }

        UpdateBGMVolumes();
    }

    public void SlideSFX(int set)
    {
        if (set == 0)
        {
            GetComponent<Slider>().value += 0.1f;
            float newVolume = GetComponent<Slider>().value;
            PlayerPrefs.SetFloat("SFX Volume", newVolume);
        }
        else
        {
            GetComponent<Slider>().value -= 0.1f;
            float newVolume = GetComponent<Slider>().value;
            PlayerPrefs.SetFloat("SFX Volume", newVolume);
        }

        UpdateSFXVolumes();
    }
}
