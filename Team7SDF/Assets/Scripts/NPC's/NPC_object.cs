using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_object : MonoBehaviour
{
    public NPC_scriptableObjects currentNpc;
    public string nameText;
    public FactionType factionText;
    public GameObject PrefabNPC;
    public QuestsScriptableObject currentQuest;

    // Start is called before the first frame update
    void Start()
    {

        nameText = currentNpc.NPC_name[Random.Range(0, currentNpc.NPC_name.Length)];
        factionText = currentNpc.factionName;
        currentQuest = currentNpc.quests[Random.Range(0, currentNpc.quests.Length)];
        PrefabNPC = currentNpc.NPC_typePrefab[Random.Range(0, currentNpc.NPC_typePrefab.Length)];
        Instantiate(PrefabNPC, transform.position, transform.rotation, transform);


        Debug.Log(currentQuest.rewardAmount);
        Debug.Log(currentQuest.questTitle);
        Debug.Log(currentQuest.questDescription);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
