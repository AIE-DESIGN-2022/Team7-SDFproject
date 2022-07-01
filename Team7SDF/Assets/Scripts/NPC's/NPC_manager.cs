using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_manager : MonoBehaviour
{
    public NPC_scriptableObjects[] NPC_Typelist;
    private NPC_scriptableObjects currentNPC;
    public GameObject NPC_prefab;
    public Transform spawnPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        
       // NPCspawn();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

;    }
    public GameObject NPCspawn()
    {
        
        currentNPC = NPC_Typelist[Random.Range(0, NPC_Typelist.Length)];
        GameObject clone = Instantiate(NPC_prefab,spawnPosition.position, spawnPosition.rotation);
        clone.GetComponent<NPC_object>().currentNpc = currentNPC;
        return clone;

    }
}

