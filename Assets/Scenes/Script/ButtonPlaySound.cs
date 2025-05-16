using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class ButtonPlaySound : MonoBehaviour
{
    [SerializeField] private Button _button;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClikButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClikButton);
    }

    private void OnClikButton()
    {
        _audioSource.Play();
    }
}
