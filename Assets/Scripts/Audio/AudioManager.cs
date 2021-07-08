using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager instance;
    private void Awake()
    {
       if(instance == null)
        instance = this;


            foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    #endregion

    public Sound[] sounds;
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
       
      
        if (s == null) 
        {
            Debug.Log( "\"" + name + "\"" + " could not be found");
            return;
        }
        s.source.Play();
    }
}
