using UnityEngine;
using UnityEngine.UI;

public class MusicAudioMixer : GameAudioMixer
{
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetMusicVolume);
    }

    private void SetMusicVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(GameData.Audio.Music, ConvertVolume(volume));
    }
}