using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip Riff1;
    public AudioClip Riff2;
    public AudioClip SoundTrack;
    public AudioClip SteelCraft;
    public AudioClip[] AllExp;

    private  AudioSource Riff1Source;
    private  AudioSource Riff2Source;
    private  AudioSource ExplosionSource;
    private  AudioSource SoundTrackSource;
    private  AudioSource SteelCraftSource;

    private int audioCount = 0;

    public void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        Riff1Source = audioSources[0]; 
        Riff2Source = audioSources[1];
        ExplosionSource = audioSources[2];
        SoundTrackSource = audioSources[3];
        SteelCraftSource = audioSources[4];

        PlaySoundTrack();
    }
    public void PlayRiff1()
    {
        Riff1Source.PlayOneShot(Riff1);
    }

    public void PlayRiff2()
    {
        Riff2Source.PlayOneShot(Riff2);
    }
    public void PlaySoundTrack()
    {
        SoundTrackSource.PlayOneShot(SoundTrack);
    }

    public void PlayExplosion()
    {
        StopAudioCLip();

        int n = Random.Range(0, AllExp.Length);
        ExplosionSource.PlayOneShot(AllExp[n]);
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

    public void PlayOneRiff()
    {
        if (audioCount < 2)
        {
            FindObjectOfType<SoundManager>().PlayRiff1();
            audioCount += 1;
        }
        else
        {
            FindObjectOfType<SoundManager>().PlayRiff2();
            audioCount = 0;
        }
    }
}
