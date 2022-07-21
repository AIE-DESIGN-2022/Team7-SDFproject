using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FactionType
{
    FactionA,
    FactionB
}

public enum UnitType
{
    Villager,
    Military,
    Trader,
    Scientist,
    Alien
}

[CreateAssetMenu(fileName = "NPC template", menuName = "ScriptableObjects/NPC", order = 1)]
public class NPC_scriptableObjects : ScriptableObject
{
    public string[] NPC_name;
    public FactionType factionName;
    public UnitType NPC_type;

    public AudioClip[] dialogueClips;

    public GameObject[] NPC_typePrefab;

    public QuestsScriptableObject[] quests;

}

