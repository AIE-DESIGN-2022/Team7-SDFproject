using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ResourceCostUpdater : MonoBehaviour
{
    public LayoutElement layoutElement;

    public int resourceCount;
    public int resourceTextCount;

    public GameObject costObjectOne;
    public GameObject costObjectTwo;
    public GameObject costObjectThree;

    public int chipCost;
    public int alloyCost;
    public int fuelCost;

    public int[] resourceCost;
    public TextMeshProUGUI[] resourceTextArray;



    public NpcDialogueTracker npcDialogueTracker;

    private void Start()
    {
        costObjectOne.SetActive(false);
        costObjectTwo.SetActive(false);
        costObjectThree.SetActive(false);
        npcDialogueTracker = FindObjectOfType<NpcDialogueTracker>();
        resourceCount = 0;
        resourceTextCount = 0;


    }

    private void Update()
    {

        if (resourceCount == 0)
        {
            layoutElement.minWidth = 0.0001f;
        }
        else if (resourceCount == 1)
        {
            layoutElement.minWidth = 172;
        }
        else if (resourceCount == 2)
        {
            layoutElement.minWidth = 360;
        }
        else if (resourceCount == 3)
        {
            layoutElement.minWidth = 576;
        }
    }
    public void QuestResourceRequirements()
    {
        if (npcDialogueTracker.trackedNPC.GetComponentInChildren<NPC_object>().currentQuest.chipRequirment > 0)
        {
            chipCost = npcDialogueTracker.trackedNPC.GetComponentInChildren<NPC_object>().currentQuest.chipRequirment ;
            UpdateResourceVisual();
        }
        if (npcDialogueTracker.trackedNPC.GetComponentInChildren<NPC_object>().currentQuest.alloyRequirment > 0)
        {
            alloyCost = npcDialogueTracker.trackedNPC.GetComponentInChildren<NPC_object>().currentQuest.alloyRequirment;
            UpdateResourceVisual();
        }
        if (npcDialogueTracker.trackedNPC.GetComponentInChildren<NPC_object>().currentQuest.fuelRequirment > 0)
        {
            fuelCost =  npcDialogueTracker.trackedNPC.GetComponentInChildren<NPC_object>().currentQuest.fuelRequirment;
            UpdateResourceVisual();

        }


        return;

    }

    public void UpdateResourceVisual()
    {
        if (resourceCount == 1)
        {
            resourceTextCount++;
            costObjectOne.SetActive(true);
            resourceTextArray[resourceTextCount].text = resourceCost[resourceCount].ToString();
        }
        if (resourceCount == 2)
        {
            resourceTextCount++;
            costObjectTwo.SetActive(true);
            resourceTextArray[resourceTextCount].text = resourceCost[resourceCount].ToString();
        }
        if (resourceCount == 3)
        {
            resourceTextCount++;
            costObjectThree.SetActive(true);
            resourceTextArray[resourceTextCount].text = resourceCost[resourceCount].ToString();
        }
    }
}
