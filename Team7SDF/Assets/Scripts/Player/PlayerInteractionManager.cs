using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    public NpcDialogueTracker npcDialogueTracker;
    public QuestsScriptableObject CurrentNPC_quest;
    public GameObject npcToTrack;
    public ResourceManager resourceManager;

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
        npcDialogueTracker.npcCount++;
        if(resourceManager.techChipCount >= CurrentNPC_quest.chipRequirment)
        {
            resourceManager.techChipCount -= CurrentNPC_quest.chipRequirment;
            resourceManager.techChipCountTextUI();
        }
        if (resourceManager.alloyCount >= CurrentNPC_quest.alloyRequirment)
        {
            resourceManager.alloyCount -= CurrentNPC_quest.alloyRequirment;
            resourceManager.alloyCountTextUI();
        }
        if (resourceManager.fuelCount >= CurrentNPC_quest.fuelRequirment)
        {
            resourceManager.fuelCount -= CurrentNPC_quest.fuelRequirment;
            resourceManager.fuelCountTextUI();
        }

        npcDialogueTracker.yesButton.SetActive(false);
        npcDialogueTracker.dialogueBox.SetActive(false);
        Debug.Log("yes");
        npcToTrack.GetComponentInChildren<NPC_navigation>().isNPC_InteractionCompleted = true;



    }
    public void NoPressed()
    {


        npcDialogueTracker.noButton.SetActive(false);
        npcDialogueTracker.dialogueBox.SetActive(false);
        Debug.Log("no");
        npcToTrack.GetComponentInChildren<NPC_navigation>().isNPC_InteractionCompleted = true;

        npcDialogueTracker.npcCount++;
    }
}
