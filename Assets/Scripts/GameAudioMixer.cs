using UnityEngine;
using UnityEngine.Audio;

public class GameAudioMixer : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private bool _isMuted;
    private float _masterVolume = 1;
    
    public void SetMasterVolume(float volume)
    {
        if(_isMuted == false)
            ChangeMasterVolume(volume);
        
        _masterVolume = volume;
    }
    
    public void SetButtonVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(GameData.Audio.Buttons, GetVolume(volume));
    }

    public void SetMusicVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(GameData.Audio.Music, GetVolume(volume));
    }

    public void ToggleMasterVolume()
    {
        if (_isMuted)
        {
            _isMuted = false;
            ChangeMasterVolume(_masterVolume);
        }
        else
        {
            ChangeMasterVolume(0);
            _isMuted = true;
        }
    }

    private void ChangeMasterVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(GameData.Audio.Master, GetVolume(volume));
    }
    
    private float GetVolume(float volume)
    {
        int minVolume = -80;
        int pitch = 20;
        
        if(volume == 0)
            return minVolume;
        
        return Mathf.Log10(volume) * pitch;
    }
}
