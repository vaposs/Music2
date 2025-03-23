using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlaySoundButton : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void OnClikButton()
    {
        _audioSource.Play();
    }
}
