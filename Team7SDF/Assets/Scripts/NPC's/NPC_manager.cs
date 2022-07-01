using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_manager : MonoBehaviour
{
    public NPC_scriptableObjects[] NPC_list;
    private NPC_scriptableObjects currentNPC;
    public GameObject NPCprefab;

    // Start is called before the first frame update
    void Start()
    {

        currentNPC = NPC_list[Random.Range(0, NPC_list.Length)];
        
        GameObject clone = Instantiate(NPCprefab);
        clone.GetComponent<NPC_object>().currentNpc = currentNPC;
    }

    // Update is called once per frame
    void Update()
    {

;    }
}

