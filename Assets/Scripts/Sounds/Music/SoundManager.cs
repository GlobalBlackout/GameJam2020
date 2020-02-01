using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip Riff1;
    public AudioClip Riff2;
    public AudioClip Explosion;
    public AudioClip SoundTrack;
    public AudioClip SteelCraft;


    private  AudioSource Riff1Source;
    private  AudioSource Riff2Source;
    private  AudioSource ExplosionSource;
    private  AudioSource SoundTrackSource;
    private  AudioSource SteelCraftSource;


    public void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        Riff1Source = audioSources[0]; 
        Riff2Source = audioSources[1];
        ExplosionSource = audioSources[2];
        SoundTrackSource = audioSources[3];
        SteelCraftSource = audioSources[4];

        PlaySoundTrack(SoundTrack);
    }
    public void PlayRiff1(AudioClip clip)
    {
        Riff1Source.PlayOneShot(clip);
    }

    public void PlayRiff2(AudioClip clip)
    {
        Riff2Source.PlayOneShot(clip);
    }
    public void PlaySoundTrack(AudioClip clip)
    {
        SoundTrackSource.PlayOneShot(clip);
    }

    public void PlayExplosion(AudioClip clip)
    {
        ExplosionSource.PlayOneShot(clip);
    }

    public void PlaySteelCraft()
    {
        SteelCraftSource.PlayOneShot(SteelCraft);
    }

    public void StopAudioCLip()
    {
        Riff1Source.Stop();
        Riff2Source.Stop();
    }


}
