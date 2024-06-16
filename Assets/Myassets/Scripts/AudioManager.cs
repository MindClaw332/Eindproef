using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    static public AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayRandomClip(AudioClip[] audioClips)
    {
        audioSource.PlayOneShot(GetRandomClip(audioClips));
    }

    public AudioClip GetRandomClip(AudioClip[] audioClips)
    {
        return audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
    }
}
