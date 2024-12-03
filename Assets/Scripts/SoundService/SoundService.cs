
using System;
using UnityEngine;

public class SoundService
{
    private AudioSource SFXAudioSource;
    private AudioSource bgAudioSource;
    private SoundTypes[] soundTypes;

    public SoundService(AudioSource sFXAudioSource, AudioSource bgAudioSource, SoundTypes[] soundTypes)
    {
        SFXAudioSource = sFXAudioSource;
        this.bgAudioSource = bgAudioSource;
        this.soundTypes = soundTypes;
    }

    public void PlayBackGroundMusic()
    {
        AudioClip item = GetAudioCLip(SoundNames.BACKGROUND_MUSIC);
        bgAudioSource.clip = item;
        bgAudioSource?.Play();
    }

    public void PlaySFX(SoundNames sound)
    {
        AudioClip item=GetAudioCLip(sound);
        SFXAudioSource.PlayOneShot(item);
    }

    private AudioClip GetAudioCLip(SoundNames soundName)
    {
        SoundTypes item = Array.Find(soundTypes, i => i.soundName == soundName);
        if(item!=null)
        {
            return item.audioClip;
        }
        return null;
    }
}
