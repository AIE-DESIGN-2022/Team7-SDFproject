using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveConfig", order = 3)]

public class NPC_Waves : ScriptableObject
{
    public List<NPC_scriptableObjects> NPCList = new List<NPC_scriptableObjects>();
}
