using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance;

    [SerializeField] AudioMixer Mixer;

    const int maxNbSounds = 16;

    int nextIndex;
    AudioSource[] sources;

    void Awake()
    {
        if (instance == null)
        {
            Init();
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    static void Check()
    {
        if (instance == null)
        {
            GameObject temp = new GameObject();
            temp.AddComponent<SoundManager>();
            DontDestroyOnLoad(temp);
        }
    }

    void Init()
    {
        nextIndex = 0;
        sources = new AudioSource[maxNbSounds];
    }

    void Update()
    {
        for (int i = 0; i < maxNbSounds; ++i)
        {
            if (instance.sources[i] != null && !instance.sources[i].isPlaying)
                Destroy(instance.sources[i]);
        }
    }

    // Manage an audio source and return it
    public static AudioSource AddSource(AudioClip clip, AudioMixerGroup group, bool loop = false , bool playNow = true)
    {
        Check();

        AudioSource src = instance.gameObject.AddComponent<AudioSource>();
        src.clip = clip;
        src.outputAudioMixerGroup = group;
        src.loop = loop;

        ManageSource(src);

        if (playNow) src.Play();

        return src;
    }

    public void MuteUnMuteMusic()
    {
        float volume;
        instance.Mixer.GetFloat("VolumeMusic", out volume);
        if(volume > -50) instance.Mixer.SetFloat("VolumeMusic", -80);
        else instance.Mixer.SetFloat("VolumeMusic", -12);
    }

    public void MuteUnMuteSfx()
    {
        float volume;
        instance.Mixer.GetFloat("VolumeSfx", out volume);
        if (volume > -50) instance.Mixer.SetFloat("VolumeSfx", -80);
        else instance.Mixer.SetFloat("VolumeSfx", -4);
    }

    // Stop all current sounds
    public static void StopAll()
    {
        Check();
        for (int i = 0; i < maxNbSounds; ++i)
        {
            if (instance.sources[i] != null)
            {
                Destroy(instance.sources[i]);
            }
        }
    }

    // Stop all current sounds with the matching tag
    public static void StopFromTag(string tag)
    {
        Check();

        for (int i = 0; i < maxNbSounds; ++i)
        {
            if (instance.sources[i] != null && instance.sources[i].tag == tag)
            {
                Destroy(instance.sources[i]);
            }
        }
    }

    static void ManageSource(AudioSource src)
    {
        Check();

        if (instance.sources[instance.nextIndex] != null)
            Destroy(instance.sources[instance.nextIndex]);

        instance.sources[instance.nextIndex] = src;

        ++instance.nextIndex;

        if (instance.nextIndex >= maxNbSounds)
            instance.nextIndex = 0;
    }
}