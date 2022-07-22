using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public void PlayClip()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
