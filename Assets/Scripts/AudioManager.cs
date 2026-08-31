using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] AudioClip _music;
    AudioMixerGroup _musicgroup;
    AudioMixerGroup _sfxgroup;
    const string MUSIC_GROUP_NAME = "Music";
    const string SFX_GROUP_NAME = "SFX";
    const string MASTER_VOLUME_NAME = "MasterVolume";
    const string MUSIC_VOLUME_NAME = "MusicVolume";
    const string SFX_VOLUME_NAME = "SFXVolume";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Init()
    {
        _musicgroup = _mixer.FindMatchingGroups(MUSIC_GROUP_NAME)[0];
        _sfxgroup = _mixer.FindMatchingGroups(SFX_GROUP_NAME)[0];

        PlayAudio(_music, SoundType.Music, 1f, true);
    }
    public void ChangeMasterVolume(float volume)
    {
        _mixer.SetFloat(MASTER_VOLUME_NAME, Mathf.Log10(volume) * 20);
    }
    public void ChangeMusicVolume(float volume)
    {
        _mixer.SetFloat(MUSIC_VOLUME_NAME, Mathf.Log10(volume) * 20);
    }
    public void ChangeSFXVolume(float volume)
    {
        _mixer.SetFloat(SFX_VOLUME_NAME, Mathf.Log10(volume) * 20);
    }
    public static AudioManager Instance { get; private set; }
    void Awake()
    {
        
        if (Instance == null)
        {
            Destroy(this);
        }
        Instance = this;
        Init();
    } 
    public enum SoundType
    {
        SFX,
        Music
    }
    public void PlayAudio(AudioClip audioClip, SoundType soundtype, float volume, bool loop)
    {
        GameObject newAudioSource = new(audioClip.name + "Source");
        AudioSource audioSource =  newAudioSource.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.loop = loop;
        switch (soundtype)
        {
            case SoundType.SFX:
                audioSource.outputAudioMixerGroup = Instance._sfxgroup; 
                break;
            case SoundType.Music:
                audioSource.outputAudioMixerGroup = Instance._musicgroup;
                break;
            default:
                break;
        }
        audioSource.Play();
        if (!loop) 
        {
            Destroy(audioSource.gameObject, audioClip.length);
        }
    }
}
