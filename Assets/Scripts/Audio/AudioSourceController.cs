using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceController : MonoBehaviour {

    public AudioClip[] sounds;
    public AudioSource source;
    public AudioMixerGroup mixerGroup;

    [Range(-80f,0f)]
    [SerializeField] private float volume = 0.0f;
    [Range(-12f,0)]
    [SerializeField] private float randomVolMin = 0.0f;
    [Range(0,12f)]
    [SerializeField] private float randomVolMax = 0.0f;

    [Range(-24f,24f)]
    [SerializeField] private float pitch = 0.0f;
    [Range(-24f,0)]
    [SerializeField] private float randomPitchMin = 0.0f;
    [Range(0f,24f)]
    [SerializeField] private float randomPitchMax = 0.0f;

    public void TryPlay()
    {
        if(!source.isPlaying) PlayImmediately();
    }

    public void RePlay()
    {
        Stop();
        PlayImmediately();
    }

    public void PlayImmediately()
    {
        AudioClip clipToPlay = sounds[Random.Range(0, sounds.Length)];
        source.clip = clipToPlay;

        source.outputAudioMixerGroup = mixerGroup;

        float finalVolume = volume + Random.Range(randomVolMin, randomVolMax);
        finalVolume = AudioConversionUtilities.dbtoLinear(finalVolume); //convert to linear for AudioSource
        source.volume = finalVolume;

        float finalPitch = pitch + Random.Range(randomPitchMin, randomPitchMax);
        finalPitch = AudioConversionUtilities.stToPitch(finalPitch); // convert to linear for AudioSource
        source.pitch = finalPitch;

        source.Play();
    }

    public void Stop()
    {
        if(source.isPlaying) source.Stop();
    }
}
