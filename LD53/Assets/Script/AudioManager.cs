using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioMixer SFXAudioMixer;
    [SerializeField] private AudioMixer musicAudioMixer;
    
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
}
