using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    public NpcDialogueTracker npcDialogueTracker;
    public QuestsScriptableObject CurrentNPC_quest;
    public GameObject npcToTrack;

    // Start is called before the first frame update
    void Start()
    {
        //CurrentNPC_quest.PlayerResponse.Clear();
        npcDialogueTracker = FindObjectOfType<NpcDialogueTracker>();
        //npcToTrack = npcDialogueTracker.trackedNPC;
        //CurrentNPCquest = npcToTrack.GetComponent<NPC_object>().currentQuest;
    }

    // Update is called once per frame
    void Update()
    {
        if (npcDialogueTracker.trackedNPC != null)
        {
            npcToTrack = npcDialogueTracker.trackedNPC.gameObject;
            CurrentNPC_quest = npcToTrack.GetComponent<NPC_object>().currentQuest;

        }
        if (npcDialogueTracker.yesButton.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Y))
        {
            YesPressed();


        }

        if (npcDialogueTracker.noButton.activeInHierarchy == true && Input.GetKeyDown(KeyCode.N))
        {
            NoPressed();
        }
    }

    public void YesPressed()
    {
        npcDialogueTracker.yesButton.SetActive(false);
        npcDialogueTracker.dialogueBox.SetActive(false);
        Debug.Log("yes");
        CurrentNPC_quest.IsPlayerAnswered = true;
        npcToTrack.GetComponentInChildren<NPC_navigation>().isNPC_InteractionCompleted = true;
        CurrentNPC_quest.PlayerResponse.Add("Y");

        npcDialogueTracker.npcCount++;

    }
    public void NoPressed()
    {
        npcDialogueTracker.noButton.SetActive(false);
        npcDialogueTracker.dialogueBox.SetActive(false);
        Debug.Log("no");
        CurrentNPC_quest.IsPlayerAnswered = true;
        npcToTrack.GetComponentInChildren<NPC_navigation>().isNPC_InteractionCompleted = true;
        CurrentNPC_quest.PlayerResponse.Add("N");

        npcDialogueTracker.npcCount++;

    }
}
