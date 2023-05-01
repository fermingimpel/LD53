using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider SFXVolume;
    [SerializeField] private Slider MusicVolume;

    private AudioManager audioManager;

    private void Start()
    {
        float sfxVolume = SFXVolume.value;
        float musicVolume = MusicVolume.value;
        
        audioManager = AudioManager.Instance;
        audioManager.GetSFXAudioMixer().GetFloat("SFXVolume", out sfxVolume);
        audioManager.GetMusicAudioMixer().GetFloat("MusicVolume", out musicVolume);
        
        MusicVolume.value = musicVolume;
        SFXVolume.value = sfxVolume;
    }

    public void SetSFXVolume(float value)
    {
        switch (audioManager.GetMixingMode())
        {
            case AudioManager.MixMode.Linear:
                audioManager.GetSFXAudioMixer().SetFloat("SFXVolume", (-80 + value * 100));
                break;
            case  AudioManager.MixMode.Logarithmic:
                audioManager.GetSFXAudioMixer().SetFloat("SFXVolume", Mathf.Log10(value) * 20);
                break;
        };
    }

    public void SetMusicVolume(float value)
    {
        switch (audioManager.GetMixingMode())
        {
            case AudioManager.MixMode.Linear:
                audioManager.GetMusicAudioMixer().SetFloat("MusicVolume", (-80 + value * 100));
                break;
            case  AudioManager.MixMode.Logarithmic:
                audioManager.GetMusicAudioMixer().SetFloat("MusicVolume", Mathf.Log10(value) * 20);
                break;
        };
    }
}
