using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    private AudioSource AudioSrc;
    private float musicVolume = 1f;

    void Start()
    {
        AudioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        AudioSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
