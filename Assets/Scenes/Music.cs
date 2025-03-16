using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private Button _AllMusicButton;
    [SerializeField] private Button _firstMusicButton;
    [SerializeField] private Button _secondMusicButton;
    [SerializeField] private Button _threeMusicButton;

    [SerializeField] private Slider _fonMusicSlider;
    [SerializeField] private Slider _effectMusicSlider;
    [SerializeField] private Slider _allMusicSlider;

    [SerializeField] private AudioSource _audioSourseOne;
    [SerializeField] private AudioSource _audioSourseTwo;
    [SerializeField] private AudioSource _audioSourseThree;
    [SerializeField] private AudioSource _audioSourseFon;

    [SerializeField] private AudioMixerGroup _audioMixer;

    bool _isPlay = true;

    private void Start()
    {
        _allMusicSlider.value = 0;
        _fonMusicSlider.value = 0;
        _effectMusicSlider.value = 0;
    }

    public void PlayMusicOne()
    {
        _audioMixer.audioMixer.SetFloat("Sound_1", 0);
        _audioSourseOne.Play();
    }

    public void PlayMusicTwo()
    {
        _audioMixer.audioMixer.SetFloat("Sound_2", 0);
        _audioSourseTwo.Play();
    }

    public void PlayMusicThree()
    {
        _audioMixer.audioMixer.SetFloat("Sound_3", 0);
        _audioSourseThree.Play();
    }

    public void ChangeVolumeButton()
    {
        _audioMixer.audioMixer.SetFloat("Sound_1", Mathf.Lerp(-80, 0, _effectMusicSlider.value));
        _audioMixer.audioMixer.SetFloat("Sound_2", Mathf.Lerp(-80, 0, _effectMusicSlider.value));
        _audioMixer.audioMixer.SetFloat("Sound_3", Mathf.Lerp(-80, 0, _effectMusicSlider.value));
    }

    public void ChangeVolumeAll()
    {
        _audioMixer.audioMixer.SetFloat("Master", Mathf.Lerp(-80, 0, _allMusicSlider.value));
    }


    public void ChangeVolumeFon()
    {
        _audioMixer.audioMixer.SetFloat("FonSound", Mathf.Lerp(-80, 0, _fonMusicSlider.value));
    }

    public void OffMusic()
    {
        if (_isPlay == true)
        {
            _audioMixer.audioMixer.SetFloat("Master", -80);
            _isPlay = false;
        }
        else
        {
            _audioMixer.audioMixer.SetFloat("Master", 0);
            _isPlay = true;
        }
    }
}
