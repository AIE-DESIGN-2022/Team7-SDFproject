using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 2)]
public class QuestsScriptableObject : ScriptableObject
{
    public int rewardAmount;
    public int cost;

}
