using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]Slider _mainSlider;
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _sfxSlider;
    const float MAIN_DEFAULT_VOLUME = 0.5f;
    const float MUSIC_DEFAULT_VOLUME = 1.0f;
    const float SFX_DEFAULT_VOLUME = 1.0f;
    public void ChangeMainVolume(float NewVol)
    {
        AudioManager.Instance.ChangeMasterVolume(NewVol);
    }
    public void ChangeMusicVolume(float NewVol)
    {
        AudioManager.Instance.ChangeMusicVolume(NewVol);
    }
    public void ChangeSFXVolume(float NewVol)
    {
        AudioManager.Instance.ChangeSFXVolume(NewVol);
    }
    void Start()
    {
        _mainSlider.value = PlayerPrefs.GetFloat("Settings.MasterVolume", MAIN_DEFAULT_VOLUME);
        _musicSlider.value = PlayerPrefs.GetFloat("Settings.MusicVolume", MUSIC_DEFAULT_VOLUME);
        _sfxSlider.value = PlayerPrefs.GetFloat("Settings.SFXVolume", SFX_DEFAULT_VOLUME);
    }
}
