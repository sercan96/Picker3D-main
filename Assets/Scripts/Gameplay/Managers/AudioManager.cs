using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
        
    public AudioSource sfxSource, musicSource;
        
    public Sound[] sounds;
    
    [SerializeField] private AudioSource pop1AS;
    [SerializeField] private AudioSource pop2AS;
    [SerializeField] private AudioSource pop3AS;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //PlayMusic(SoundType.Main);
    }

    public void PlaySfx(SoundType soundType)
    {
        Sound sound = Array.Find(sounds, sound => sound.soundType == soundType);

        sfxSource.clip = sound.clip;
        sfxSource.Play();
    }
        
    public void PlayMusic(SoundType soundType)
    {
        Sound sound = Array.Find(sounds, sound => sound.soundType == soundType);

        musicSource.clip = sound.clip;
        musicSource.Play();
    }
    
    public void PlayPopSound()
    {
        if (!pop1AS.isPlaying)
        {
            pop1AS.Play();
        }
        else if (!pop2AS.isPlaying)
        {
            pop2AS.Play();
        }
        else
        {
            pop3AS.Stop();
            pop3AS.Play();
        }
    }
}
    
[Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip clip;
}

public enum SoundType
{
    Main,
    BallTouch,
    Success,
    Fail
}

