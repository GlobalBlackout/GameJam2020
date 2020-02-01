using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    public AudioClip Riff1;
    public AudioClip Riff2;
    public AudioClip Explosion;
    public AudioClip SoundTrack;
    public AudioClip SteelCraft;


    private static AudioSource Riff1Source;
    private static AudioSource Riff2Source;
    private static AudioSource ExplosionSource;
    private static AudioSource SoundTrackSource;
    private static AudioSource SteelCraftSource;


    public void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        else if(Instance != null)
        {
            Destroy(gameObject);
        }

        AudioSource[] audioSources = GetComponents<AudioSource>();


        Riff1Source = audioSources[0]; 
        Riff2Source = audioSources[1];
        ExplosionSource = audioSources[2];
        SoundTrackSource = audioSources[3];
        SteelCraftSource = audioSources[4];

        PlaySoundTrack(SoundTrack);


    }
    public static void PlayRiff1(AudioClip clip)
    {
        Riff1Source.PlayOneShot(clip);
    }

    public static void PlayRiff2(AudioClip clip)
    {
        Riff2Source.PlayOneShot(clip);
    }
    public static void PlaySoundTrack(AudioClip clip)
    {
        SoundTrackSource.PlayOneShot(clip);
    }

    public static void PlayExplosion(AudioClip clip)
    {
        ExplosionSource.PlayOneShot(clip);
    }

    public static void PlaySteelCraft(AudioClip clip)
    {
        SteelCraftSource.PlayOneShot(clip);
    }

    public static void StopAudioCLip()
    {
        Riff1Source.Stop();
        Riff2Source.Stop();
    }


}
