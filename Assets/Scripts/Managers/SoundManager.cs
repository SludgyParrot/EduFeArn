using System;
using UnityEngine;

public class SoundManager : Singletons<SoundManager>
{
    [SerializeField]
    private AudioSource audioSource;

    protected override void Init()
    {
        base.Init();

        if(audioSource == null)
        {
            throw new NullReferenceException("Sound manager initialization failed: audio source component is not assigned from the Unity inspector panel.");
        }
    }

    public void PlayClip(AudioClip clip, bool loop = false)
    {
        if(clip == null)
        {
            throw new ArgumentNullException("Play clip failed: clip parameter value cannot be null.");
        }

        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
    }
}
