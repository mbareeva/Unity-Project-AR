using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBeeStings : MonoBehaviour
{
    public static AudioSource audioSource;
    public static AudioClip clip;
    public static float volume = 0.5f;

    public static void Play()
    {
        audioSource.Play();
    }
}