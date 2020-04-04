using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds; // Array containing our clips

    public static SoundManager instance; // checks to see if scene already has a sound manager.

    private void Awake()
    {
        /*if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }*/ 
        // if-else for if we want a continuous manager (stays between scenes)
        //DontDestroyOnLoad(gameObject); // for continuous manager.
        
        foreach (Sound s in sounds) // assigns each sound in the array to an AudioSource.
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) // plays sound
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found you egg.");
            return;
        }
        
        s.source.Play();
    }
}
