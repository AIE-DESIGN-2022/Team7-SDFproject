using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogueTracker : MonoBehaviour
{
    public int npcCount;

    public GameObject dialogueBox;
    public GameObject trackedNPC;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI dialogueText;
    public Image factionIcon;

    //public eNPCstate npcState;

    NPC_manager npcManager;
    NPC_object npcObject;
    NPC_navigation npcNavigation;
    NPC_WaveManager npcWaveManager;
    public ResourceCostUpdater npcResourceCostUpdater;
    public PlayerInteractionManager playerInteractionManager;

    void Start()
    {
        dialogueBox.SetActive(false);
        playerInteractionManager = FindObjectOfType<PlayerInteractionManager>();
        npcWaveManager = FindObjectOfType<NPC_WaveManager>();
        npcManager = FindObjectOfType<NPC_manager>();
        npcObject = FindObjectOfType<NPC_object>();
        npcNavigation = FindObjectOfType<NPC_navigation>();
        npcResourceCostUpdater = FindObjectOfType<ResourceCostUpdater>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("InteractingNPC") != null)
        {

            GetCurrentNpcData();

        }
    }

    public void GetCurrentNpcData()
    {
        trackedNPC = GameObject.FindGameObjectWithTag("InteractingNPC");

        if (trackedNPC.GetComponentInChildren<NPC_navigation>().isNPC_InteractionPointOccupied == true)
        {



            npcName.text = trackedNPC.GetComponentInChildren<NPC_object>().nameText;
            dialogueText.text = trackedNPC.GetComponentInChildren<NPC_object>().currentQuest.questDescription;
            npcResourceCostUpdater.QuestResourceRequirements();



            //dialogueBox.SetActive(true);
            //playerInteractionManager.responceBox.SetActive(true);

            //Debug.Log(trackedNPC);
            //Debug.Log(dialogueText.text);
            //Debug.Log(npcName.text);


        }
        else
        {
            return;
        }
    }
}
