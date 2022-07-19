using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogueTracker : MonoBehaviour
{
    public int npcCount;

    public GameObject yesButton;
    public GameObject noButton;

    public GameObject dialogueBox;
    public NPC_object trackedNPC;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI dialogueText;
    public Image factionIcon;

    //public eNPCstate npcState;

    NPC_manager npcManager;
    NPC_object npcObject;
    NPC_navigation npcNavigation;
    NPC_WaveManager npcWaveManager;

    ResourceManager resourceManager;
    public ResourceCostUpdater npcResourceCostUpdater;
    public PlayerInteractionManager playerInteractionManager;
    [Header("Icons")]
    public GameObject costObject;
    public Transform resourceBox;

    public Sprite chipIcon;
    public Sprite alloyIcon;
    public Sprite fuelIcon;

    public List<GameObject> costItems;

    void Start()
    {
        dialogueBox.SetActive(false);

        yesButton.SetActive(false);
        noButton.SetActive(false);

        resourceManager = FindObjectOfType<ResourceManager>();
        playerInteractionManager = FindObjectOfType<PlayerInteractionManager>();
        npcWaveManager = FindObjectOfType<NPC_WaveManager>();
        npcManager = FindObjectOfType<NPC_manager>();
        npcObject = FindObjectOfType<NPC_object>();
        npcNavigation = FindObjectOfType<NPC_navigation>();
        npcResourceCostUpdater = GetComponentInChildren<ResourceCostUpdater>();


    }

    // Update is called once per frame
    void Update()
    {
/*        if (GameObject.FindGameObjectWithTag("InteractingNPC") != null)
        {
            GetCurrentNpcData();
        }*/
    }

    public void GetCurrentNpcData(NPC_object currentNPC)
    {
        trackedNPC = currentNPC;
        yesButton.GetComponent<Button>().interactable = true;
        // NPC_object currentNpcObject = trackedNPC.GetComponentInChildren<NPC_object>();
        if (trackedNPC.GetComponentInChildren<NPC_navigation>().isNPC_InteractionPointOccupied == true)
        {
            npcName.text = trackedNPC.nameText;
            dialogueText.text = trackedNPC.currentQuest.questDescription;
            
            if(trackedNPC.currentQuest.chipRequirment > 0)
            {
                GameObject resourceClone = Instantiate(costObject, resourceBox);
                costItems.Add(resourceClone);
                ResourceCostFinder finder = resourceClone.GetComponent<ResourceCostFinder>();
                finder.resourceIcon.sprite = chipIcon;
                finder.costText.text = trackedNPC.currentQuest.chipRequirment.ToString();
                if(resourceManager.techChipCount < trackedNPC.currentQuest.chipRequirment)
                {
                    yesButton.GetComponent<Button>().interactable = false;
                }
            }
            if (trackedNPC.currentQuest.alloyRequirment > 0)
            {
                GameObject resourceClone = Instantiate(costObject, resourceBox);
                costItems.Add(resourceClone);
                ResourceCostFinder finder = resourceClone.GetComponent<ResourceCostFinder>();
                finder.resourceIcon.sprite = alloyIcon;
                finder.costText.text = trackedNPC.currentQuest.alloyRequirment.ToString();
                if (resourceManager.alloyCount < trackedNPC.currentQuest.alloyRequirment)
                {
                    yesButton.GetComponent<Button>().interactable = false;
                }
            }
            if (trackedNPC.currentQuest.fuelRequirment > 0)
            {
                GameObject resourceClone = Instantiate(costObject, resourceBox);
                costItems.Add(resourceClone);
                ResourceCostFinder finder = resourceClone.GetComponent<ResourceCostFinder>();
                finder.resourceIcon.sprite = fuelIcon;
                finder.costText.text = trackedNPC.currentQuest.fuelRequirment.ToString();
                if (resourceManager.fuelCount < trackedNPC.currentQuest.fuelRequirment)
                {
                    yesButton.GetComponent<Button>().interactable = false;
                }
            }

        }
        else
        {
            return;
        }


    }
    public void ClearCurrentNpcData()
    {
        foreach(GameObject go in costItems)
        {
            Destroy(go);
        }
        costItems.Clear(); 
    }
}
