using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 2)]
public class QuestsScriptableObject : ScriptableObject
{
    public int rewardAmount;
    public int cost;

    /*public enum QuestLine
    {
        QuestlineA,
        QuestLineB,
        QuestlineC
    }
    */


    //public QuestLine questline;

    public string questTitle;
    public string questDescription;

   
    //if quest has reqirments 
    public int chipRequirment;
    public int alloyRequirment;
    public int fuelRequirment;



    public int populationConsequence;
    public float happinessConsequence;
    public int researchConsequence;
    public int currencyConsequence;

    public bool IsPlayerAnswered;

    public List<string> PlayerResponse;

}

