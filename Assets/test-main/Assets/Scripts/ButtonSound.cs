using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    private AudioClip buttonClickSound;
    private AudioSource buttonSource;

    void Start()
    {
        buttonClickSound = GetComponent<AudioClip>();
    }

    public void ButtonClickSound()
    {
        buttonSource.PlayOneShot(buttonClickSound);
    }

}
