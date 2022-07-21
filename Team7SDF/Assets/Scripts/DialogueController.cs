using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{

    public NPC_navigation nPC_Navigation;
    public GameObject ThisNPC;
    public AudioSource audioSource;
    public NPC_object nPC_Object;
    void Start()
    {
        ThisNPC = this.gameObject;
        nPC_Object = GetComponent<NPC_object>();
        audioSource = GetComponent<AudioSource>();
        nPC_Navigation = GetComponentInChildren<NPC_navigation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayDialogue()
    {
    
            audioSource.clip = nPC_Object.currentDialogue;
            audioSource.Play();
    }
}
