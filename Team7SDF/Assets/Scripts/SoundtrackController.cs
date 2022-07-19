using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackController : MonoBehaviour
{
    public NPC_WaveManager waveManager; 
    public AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        waveManager = FindObjectOfType<NPC_WaveManager>();
        ChangeSoundtrack();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private AudioClip GetAudioClip(string audioClipName)
    {
        if (audioClips.Count > 0)
        {
            foreach (AudioClip clip in audioClips)
            {
                if (clip.name == audioClipName) return clip;

            }
        }
        return null;
    }
    public void PlayAudioClip(string audioClipName)
    {

        AudioClip clip = GetAudioClip(audioClipName);
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.Log("Audio Clip " + audioClipName + " not Found");
        }

    }
    public void ChangeSoundtrack()
    {
        if(waveManager.yearCount == 1)
        {
            Debug.Log("Audio Level 1");
            PlayAudioClip("Level 1");
        }
        if (waveManager.yearCount == 2)
        {
            PlayAudioClip("Level 2");
            Debug.Log("Audio Level 2");
        }
        if (waveManager.yearCount == 3)
        {
            PlayAudioClip("Level 3");
            Debug.Log("Audio Level 3");
        }
        if (waveManager.yearCount >= 4)
        {
            PlayAudioClip("Level 4");
            Debug.Log("Audio Level 4");
        }
    }
}
