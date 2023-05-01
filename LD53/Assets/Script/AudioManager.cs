using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public enum MixMode
    {
        Linear,
        Logarithmic
    }
    
    [Header("Sources")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicSource;
    [Header("Mixers")]
    [SerializeField] private AudioMixer SFXAudioMixer;
    [SerializeField] private AudioMixer musicAudioMixer;
    [Header("Settings")]
    [SerializeField] private MixMode mixMode;
    
    
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Play2DSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if(musicSource.isPlaying)
            musicSource.Stop();
        
        musicSource.loop = true;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public AudioMixer GetMusicAudioMixer()
    {
        return musicAudioMixer;
    }

    public AudioMixer GetSFXAudioMixer()
    {
        return SFXAudioMixer;
    }

    public MixMode GetMixingMode()
    {
        return mixMode;
    }
}
