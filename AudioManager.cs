using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip cursor;
    public AudioClip drop;
    public AudioSource audioSource;
    public AudioClip control;
    public AudioClip lineClear;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCursor() { 
        PlayAudio(cursor);
    
    }
    public void PlayDrop()
    {
        PlayAudio(drop);
    }
    public void PlayControl() {
        PlayAudio(control);
        
    }
    public void PlayLineClear() { 
        PlayAudio(lineClear);
    }
    private void PlayAudio(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
