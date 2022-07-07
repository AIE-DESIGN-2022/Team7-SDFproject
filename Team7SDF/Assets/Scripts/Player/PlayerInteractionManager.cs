using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{

    public GameObject responceBox;
    public NpcDialogueTracker npcDialogueTracker;
    public QuestsScriptableObject CurrentNPC_quest;
    public GameObject npcToTrack;

    // Start is called before the first frame update
    void Start()
    {
        responceBox.SetActive(false);   
        npcDialogueTracker = FindObjectOfType<NpcDialogueTracker>();
        //npcToTrack = npcDialogueTracker.trackedNPC;
        //CurrentNPCquest = npcToTrack.GetComponent<NPC_object>().currentQuest;
    }

    // Update is called once per frame
    void Update()
    {
        if(npcDialogueTracker.trackedNPC != null)
        {
        npcToTrack = npcDialogueTracker.trackedNPC;
        CurrentNPC_quest = npcToTrack.GetComponent<NPC_object>().currentQuest;

        }
        if (responceBox.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Y))
        {
            YesPressed();
            

        }

        if (responceBox.activeInHierarchy == true && Input.GetKeyDown(KeyCode.N))
        {
            NoPressed();
        }
    }

    public void YesPressed()
    {
        npcDialogueTracker.npcCount++;
        Debug.Log("yes");
        CurrentNPC_quest.IsPlayerAnswered = true;
        npcToTrack.GetComponentInChildren<NPC_navigation>().isNPC_InteractionCompleted = true;
        CurrentNPC_quest.PlayerResponse.Add("Y");
        responceBox.SetActive(false);
    }
    public void NoPressed()
    {
        npcDialogueTracker.npcCount++;
        Debug.Log("no");
        CurrentNPC_quest.IsPlayerAnswered = true;
        npcToTrack.GetComponentInChildren<NPC_navigation>().isNPC_InteractionCompleted = true;
        CurrentNPC_quest.PlayerResponse.Add("N");
        responceBox.SetActive(false);
    }
}
