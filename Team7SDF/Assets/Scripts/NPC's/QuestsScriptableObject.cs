using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 2)]
public class QuestsScriptableObject : ScriptableObject
{
 

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




}

