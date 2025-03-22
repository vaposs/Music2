using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour
{
    [SerializeField] private Toggle _muteAllSound;

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

    [SerializeField] private AudioMixer _audioMixer;

    private float _minValueSlider = 0.0001f;
    private float _maxValueSlider = 1f;
    private int _modifierMepevodDicebels = 20;


    private void Start()
    {
        _allMusicSlider.minValue = _minValueSlider;
        _fonMusicSlider.minValue = _minValueSlider;
        _effectMusicSlider.minValue = _minValueSlider;

        _allMusicSlider.maxValue = _maxValueSlider;
        _fonMusicSlider.maxValue = _maxValueSlider;
        _effectMusicSlider.maxValue = _maxValueSlider;

        _allMusicSlider.value = _minValueSlider;
        _fonMusicSlider.value = _minValueSlider;
        _effectMusicSlider.value = _minValueSlider;

        _audioMixer.SetFloat("Sound_1", Mathf.Log10(_effectMusicSlider.value) * _modifierMepevodDicebels);
        _audioMixer.SetFloat("Sound_2", Mathf.Log10(_effectMusicSlider.value) * _modifierMepevodDicebels);
        _audioMixer.SetFloat("Sound_3", Mathf.Log10(_effectMusicSlider.value) * _modifierMepevodDicebels);
        _audioMixer.SetFloat("FonSound", Mathf.Log10(_fonMusicSlider.value) * _modifierMepevodDicebels);
        _audioMixer.SetFloat("Master", Mathf.Log10(_allMusicSlider.value) * _modifierMepevodDicebels);
    }

    public void PlayMusicOne()
    {
        _audioSourseOne.Play();
    }

    public void PlayMusicTwo()
    {
        _audioSourseTwo.Play();
    }

    public void PlayMusicThree()
    {
        _audioSourseThree.Play();
    }

    public void ChangeVolumeButton()
    {
        _audioMixer.SetFloat("Sound_1", Mathf.Log10(_effectMusicSlider.value) * _modifierMepevodDicebels);
        _audioMixer.SetFloat("Sound_2", Mathf.Log10(_effectMusicSlider.value) * _modifierMepevodDicebels);
        _audioMixer.SetFloat("Sound_3", Mathf.Log10(_effectMusicSlider.value) * _modifierMepevodDicebels);
    }

    public void ChangeVolumeAll()
    {
        _audioMixer.SetFloat("Master", Mathf.Log10(_allMusicSlider.value) * _modifierMepevodDicebels);
    }


    public void ChangeVolumeFon()
    {
        _audioMixer.SetFloat("FonSound", Mathf.Log10(_fonMusicSlider.value) * _modifierMepevodDicebels);
    }

    public void MuteMusic()
    {
        if(_muteAllSound.isOn == false)
        {
            _audioSourseOne.mute = true;
            _audioSourseTwo.mute = true;
            _audioSourseThree.mute = true;
            _audioSourseFon.mute = true;
        }
        else
        {
            _audioSourseOne.mute = false;
            _audioSourseTwo.mute = false;
            _audioSourseThree.mute = false;
            _audioSourseFon.mute = false;
        }

    }
}
