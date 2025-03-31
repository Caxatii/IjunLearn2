using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterAudioMixer : GameAudioMixer
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _button;
    
    private bool _isMuted;
    private float _masterVolume = 1;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetMasterVolume);
        _button.onClick.AddListener(ToggleMasterVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetMasterVolume);
        _button.onClick.RemoveListener(ToggleMasterVolume);
    }

    private void SetMasterVolume(float volume)
    {
        if(_isMuted == false)
            ChangeMasterVolume(volume);
        
        _masterVolume = volume;
    }

    private void ToggleMasterVolume()
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
        _mixer.audioMixer.SetFloat(GameData.Audio.Master, ConvertVolume(volume));
    }
}