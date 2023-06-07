using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        //LINQ IMPLEMENTATION
        AudioSource ausource = Sources.Where(s => !s.isPlaying).FirstOrDefault();
        if (ausource != null)
        {
            ausource.clip = _clip;
            ausource.Play();
        }
    }
}
