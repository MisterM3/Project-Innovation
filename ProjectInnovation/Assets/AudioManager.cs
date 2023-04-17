using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[Serializable]
public class Sound
{
    public string name;
    public AudioSource source;
}

public class AudioManager : MonoBehaviour
{

    public AudioManager Instance { get; private set; }

    [SerializeField] List<Sound> soundList;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            Debug.LogError("Already a AudioManger, removing: " + this.name);
            return;
        }

        Instance = this;
    }

    public void PlaySound(string name)
    {
        foreach(Sound sound in soundList)
        {
            if (sound.name != name) continue;

            sound.source.Play();
            
        }
    }
}
