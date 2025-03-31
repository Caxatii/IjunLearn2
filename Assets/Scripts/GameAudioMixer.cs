using System;
using UnityEngine;
using UnityEngine.Audio;

public abstract class GameAudioMixer : MonoBehaviour
{
    [SerializeField] protected AudioMixerGroup _mixer;
    
    protected float ConvertVolume(float volume)
    {
        int minVolume = -80;
        int pitch = 20;
        
        if(volume == 0)
            return minVolume;
        
        return Mathf.Log10(volume) * pitch;
    }
}