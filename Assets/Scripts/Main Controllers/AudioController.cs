using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoSingleton<AudioController>
{
    //DATA
    //TECHNICAL

    //
    public AudioSource[] Sources;


    //METHODS

    //TECHNICAL
    private void Start()
    {
        Sources = GetComponents<AudioSource>();
    }

    public void PlayClip(AudioClip _clip)
    {
        for (int i = 0; i < Sources.Length; i++)
        {
            if (!Sources[i].isPlaying)
            {
                Sources[i].clip = _clip;
                Sources[i].Play();
                break;
            }
        }
    }
}
