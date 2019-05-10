using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    public Sound[] sounds;
    private List<AudioSource> sfxSources;
    private List<AudioSource> musicSources;

    private Dictionary<string, Sound> soundsDict;

    public void ChangeSFXVolume(float value)
    {
        foreach (AudioSource a in sfxSources)
        {
            Debug.Log("here");
            a.volume = value;
        }
    }

    public void ChangeMusicVolume(float value)
    {
        foreach (AudioSource a in musicSources)
        {
            a.volume = value;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        soundsDict = new Dictionary<string, Sound>();
        sfxSources = new List<AudioSource>();
        musicSources = new List<AudioSource>();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            soundsDict.Add(s.name, s);

            if (s.type == "sfx")
                sfxSources.Add(s.source);

            if (s.type == "music")
                musicSources.Add(s.source);

        }
    }

    public void Play(string name)
    {
        if (soundsDict[name].source.isPlaying)
            return;
        else
            soundsDict[name].source.Play();
    }

    public void PlayOverlapping(string name)
    {
        soundsDict[name].source.PlayOneShot(soundsDict[name].source.clip);
    }

    public void Stop(string name)
    {
        soundsDict[name].source.Stop();
    }
}

