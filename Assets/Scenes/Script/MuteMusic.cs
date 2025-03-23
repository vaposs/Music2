using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]

public class MuteMusic : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;

    private Toggle _muteAllSound;

    private void Start()
    {
        _muteAllSound = GetComponent<Toggle>();
    }

    public void Mute()
    {
        OffOnMusic(_muteAllSound.isOn);
    }

    private void OffOnMusic(bool state)
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.mute = state;
        }
    }
}
