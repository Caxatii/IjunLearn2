using UnityEngine;
using UnityEngine.UI;

public class ButtonAudioMixer : GameAudioMixer
{
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetButtonVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetButtonVolume);
    }

    private void SetButtonVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(GameData.Audio.Buttons, ConvertVolume(volume));
    }
}