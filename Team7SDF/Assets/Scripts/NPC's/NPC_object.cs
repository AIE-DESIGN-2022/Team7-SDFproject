using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_object : MonoBehaviour
{
    public NPC_scriptableObjects currentNpc;
    public string nameText;
    public FactionType factionText;
    public QuestsScriptableObject currentQuest;

    // Start is called before the first frame update
    void Start()
    {
        nameText = currentNpc.NPC_name[Random.Range(0, currentNpc.NPC_name.Length)];
        factionText = currentNpc.factionName;
        currentQuest = currentNpc.quests[Random.Range(0, currentNpc.quests.Length)];
        Debug.Log(currentQuest.rewardAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
