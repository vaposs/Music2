using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SliderVolumeChange : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string[] _nameGroupSourses;

    private Slider _slider;
    private float _minValueSlider = 0.0001f;
    private float _maxValueSlider = 1f;
    private int _modifierMepevodDicebels = 20;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        _slider.minValue = _minValueSlider;
        _slider.maxValue = _maxValueSlider;
        _slider.value = _minValueSlider;

        ChangeCountVolume();
    }

    public void ChangeCountVolume()
    {
        foreach (string nameSourse in _nameGroupSourses)
        {
            _audioMixer.SetFloat(nameSourse, Mathf.Log10(_slider.value) * _modifierMepevodDicebels);
        }
    }
}
