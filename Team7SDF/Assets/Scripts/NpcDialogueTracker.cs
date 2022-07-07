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

    void Start()
    {
        dialogueBox.SetActive(false);

        npcWaveManager = FindObjectOfType<NPC_WaveManager>();   
        npcManager = FindObjectOfType<NPC_manager>();
        npcObject = FindObjectOfType<NPC_object>();
        npcNavigation = FindObjectOfType<NPC_navigation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (npcManager.clone != null)
        {
            
            Debug.Log("ahhhhhhhh");
            GetCurrentNpcData();
        }
    }

    public void GetCurrentNpcData()
    {
        trackedNPC = npcWaveManager.currentWave[npcCount];

        if (trackedNPC.GetComponentInChildren<NPC_navigation>().isNPC_InteractionPointOccupied == true)
        {
            if (trackedNPC.GetComponentInChildren<NPC_navigation>().isNPC_InteractionPointOccupied == false)
            {
                return;
            }
            else
            {
            npcCount++;
            npcName.text = trackedNPC.GetComponent<NPC_object>().nameText;
            dialogueText.text = trackedNPC.GetComponent<NPC_object>().currentQuest.questDescription;

            dialogueBox.SetActive(true);

            Debug.Log(trackedNPC);
            Debug.Log(dialogueText.text);
            Debug.Log(npcName.text);

            }
         
        }
        else
        {
            return;
        }
    }
}
