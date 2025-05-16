
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SliderVolumeChange : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _nameMixerGroup;

    private Slider _slider;
    private float _minValueSlider = 0.0001f;
    private float _maxValueSlider = 1f;
    private int _modifierMepevodDicebels = 20;
    private float _minValueMixer = -80f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.minValue = _minValueSlider;
        _slider.maxValue = _maxValueSlider;
        _slider.value = _minValueSlider;

        ChangeCountVolume(_minValueSlider);
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeCountVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeCountVolume);
    }

    private void ChangeCountVolume(float stub)
    {
        _audioMixer.SetFloat(_nameMixerGroup, Mathf.Log10(_slider.value) * _modifierMepevodDicebels);

        if (_slider.value == _slider.minValue)
        {
            _audioMixer.SetFloat(_nameMixerGroup, _minValueMixer);
        }
    }
}
