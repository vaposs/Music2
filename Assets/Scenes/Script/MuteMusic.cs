using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]

public class MuteMusic : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Toggle _muteAllSound;
    [SerializeField] private Slider _slider;

    private int _modifierMepevodDicebels = 20;
    private float _offMusicValue = -80;

    private void Awake()
    {
        _muteAllSound = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _muteAllSound.onValueChanged.AddListener(OffOnMusic);
    }

    private void OnDisable()
    {
        _muteAllSound.onValueChanged.RemoveListener(OffOnMusic);
    }

    private void OffOnMusic(bool state)
    {
        if(state)
        {
            _audioMixer.SetFloat("Master", _offMusicValue);
        }
        else
        {
            _audioMixer.SetFloat("Master", Mathf.Log10(_slider.value) * _modifierMepevodDicebels);
        }
    }
}
