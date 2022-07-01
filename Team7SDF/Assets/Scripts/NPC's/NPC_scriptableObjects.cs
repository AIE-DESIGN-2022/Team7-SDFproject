using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FactionType
{
    FactionA,
    FactionB
}

[CreateAssetMenu(fileName = "NPC template", menuName = "ScriptableObjects/NPC", order = 1)]
public class NPC_scriptableObjects : ScriptableObject
{
    public string[] NPC_name;
    public FactionType factionName;
    public string[] NPC_type;

    public GameObject[] NPC_typePrefab;

    public QuestsScriptableObject[] quests;

}

